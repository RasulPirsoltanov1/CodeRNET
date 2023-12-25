using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VCard.Models
{
    public class Card
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string GetVCard()
        {
            try
            {
                string vCard = "BEGIN:VCARD\r\nVERSION:3.0\r\n";
                vCard += $"FN:{Firstname} {Surname}\r\n";
                vCard += $"EMAIL:{Email}\r\n";
                vCard += $"TEL:{Phone}\r\n";
                vCard += $"ADR;TYPE=WORK:;;{City};;{Country}\r\n";
                vCard += $"UID:{Id}\r\n";
                vCard += "END:VCARD";
                return vCard;
            }
            catch (Exception)
            {

                throw new Exception("something went wrong");
            }
        }
        public bool SaveVCard(string card,string cardId)
        {
            string directoryPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\","files"));
            string filePath = Path.Combine(directoryPath, $"card{cardId}.vcf");

            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                if(File.Exists(filePath))
                {
                    return false;
                }

                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] writeArr = Encoding.UTF8.GetBytes(card);
                    stream.Write(writeArr, 0, writeArr.Length);
                    stream.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving vCard to file: {ex.Message}");
                return false;
            }
        }


    }
}
