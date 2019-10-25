using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using PrizeDraw.DataLayer.Model.Identity;
using System.IO;
using PrizeDraw.DataLayer.Providers;
using System.Threading.Tasks;
using PrizeDraw.DataLayer.Model;

namespace PrizeDrawTool
{
    internal class UserGenerator
    {
        private string ConnectionString { get; set; }

        private IList<(User, string)> UserPasswords { get; set; } = new List<(User, string)>();

        private static RNGCryptoServiceProvider _rngCrypto = new RNGCryptoServiceProvider();

        public UserGenerator(string connectionString) => ConnectionString = connectionString;

        public async Task GenerateUsersForVendors()
        {
            RoleProvider roleProvider = new RoleProvider(ConnectionString);
            VendorProvider vendorProvider = new VendorProvider(ConnectionString);
            UserProvider userProvider = new UserProvider(ConnectionString);

            Role vendorRole = roleProvider.GetRoleBy("vendor");

            foreach (Vendor vendor in vendorProvider.GetVendors().ToList())
            {
                string vendorUserName = VendorNameToUserName(vendor.Name);

                User user = userProvider.GetUserBy(vendorUserName);
                if (user == null)
                {
                    user = new User
                    {
                        UserName = vendorUserName,
                        VendorId = vendor.Id
                    };

                    CreatePasswordForUser(user);

                    userProvider.Add(user);
                    await userProvider.SaveAsync();
                }

                if (!roleProvider.UserIsInRole(vendorRole.Id, user.Id))
                {
                    // Add to vendor role
                    UserRole userRole = new UserRole
                    {
                        RoleId = vendorRole.Id,
                        UserId = user.Id
                    };

                    roleProvider.Add(userRole);
                    await roleProvider.SaveAsync();
                }
            }
        }

        public async Task GenerateUserPasswords()
        {
            UserProvider provider = new UserProvider(ConnectionString);


            foreach (User user in provider.GetUsers())
            {
                //TODO Dirty code. exclude this at the DB level to get rid of the if statement. 
                //The idea is to replace the GetUsers() method with a new one where it will honour the following SQL:
                //SELECT * 
                //      FROM Users 
                //      WHERE HashPassword IS NULL
                //;

                //If user does not have a password
                if (user.PasswordHash == null)
                {
                    //Generate a password
                    CreatePasswordForUser(user);
                }
            }

            await provider.SaveAsync();
        }

        private void CreatePasswordForUser(User user)
        {
            // eight character password is good enough for what we're doing.
            string password = GenerateRandomString(8);
            user.PasswordHash = HashPassword(password);

            UserPasswords.Add((user, password));
        }

        private string VendorNameToUserName(string vendorName)
        {
            // strip out spaces first, then truncate
            string userName = vendorName.Replace(" ", "")
                .Replace("/", ".")
                .Replace("\\", ".")
                .ToLowerInvariant();

            return (userName.Length > 10) ? userName.Substring(0, 10) : userName;
        }

        private string GenerateRandomString(int length)
        {
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = (char)Next(48, 126);
            }

            return new string(chars);
        }

        private uint Next(Int32 minValue, Int32 maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(minValue));
            }
            if (maxValue < minValue)
            {
                throw new ArgumentOutOfRangeException(nameof(maxValue));
            }

            byte[] uint32Buffer = new byte[8];

            long diff = maxValue - minValue;
            uint returnValue;
            while (true)
            {
                _rngCrypto.GetBytes(uint32Buffer);
                uint rand = BitConverter.ToUInt32(uint32Buffer, 0);

                long max = (1 + (long)uint.MaxValue);
                long remainder = max % diff;
                if (rand < max - remainder)
                {
                    returnValue = (uint)(minValue + (rand % diff));
                    break;
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Writing the passwords to a file where the filename is timestamped, this is to avoid overwriting existing files.
        /// </summary>
        /// <param name="path"></param>
        public void WritePasswordsToFile(string path)
        {
            //Declaring the variable to store the name of the File as fileName
            String fileName = "UserList";

            //Getting the current DateTime as a String
            String timeStamp = (DateTime.Now).ToString("yyyy-MM-ddTHHmmss");

            //Adding the timeStamp to fileName with a dash
            fileName += "-" + timeStamp;
            //Adding the extension
            fileName += ".csv";

            using (StreamWriter streamWrite = File.CreateText(path + "\\"+fileName))
            {
                foreach ((User, string) userPassword in UserPasswords)
                {
                    streamWrite.WriteLine(userPassword.Item1.UserName + ", " + userPassword.Item2);
                }
            }
        }

        private byte[] HashPasswordV3(string password, RandomNumberGenerator rng)
        {
            return HashPasswordV3(password, rng,
                prf: KeyDerivationPrf.HMACSHA256,
                iterCount: 10000,
                saltSize: 128 / 8,
                numBytesRequested: 256 / 8);
        }

        private string HashPassword(string password)
        {
            string hashed;
            using (var rng = RandomNumberGenerator.Create())
            {
                hashed = Convert.ToBase64String(HashPasswordV3(password, rng));
            }

            return hashed;
        }

        private static byte[] HashPasswordV3(string password, RandomNumberGenerator rng, KeyDerivationPrf prf, int iterCount, int saltSize, int numBytesRequested)
        {
            // Produce a version 3 text hash.
            byte[] salt = new byte[saltSize];
            rng.GetBytes(salt);
            byte[] subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

            var outputBytes = new byte[13 + salt.Length + subkey.Length];
            outputBytes[0] = 0x01; // format marker
            WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
            WriteNetworkByteOrder(outputBytes, 5, (uint)iterCount);
            WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);

            return outputBytes;
        }

        private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }
    }
}
