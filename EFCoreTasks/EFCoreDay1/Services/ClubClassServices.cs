using EFCoreDay1.Controller;
using EFCoreDay1.Data;
using EFCoreDay1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EFCoreDay1.Services
{
    public class ClubClassServices
    {
       
        public static Clubs FetchInputForAddClubs()
        {
            Clubs clubs = new Clubs();
            Console.WriteLine("Enter Club Name");
            clubs.Name = Console.ReadLine() ?? "TestClubs";

            Console.WriteLine();

            return clubs;
        }

        public static void AttachBehaviourAndLogging(AppDbContext appDbContext,Clubs club)
        {
            var print = (string msg) =>
            {
                int maxId = appDbContext.Clubs.Max(x => x.Id);
                Console.WriteLine(msg + appDbContext.Clubs.FirstOrDefault(x => x.Id == maxId)?.Name);
            };

            appDbContext.Clubs.Add(club);
            appDbContext.SaveChanges();
            print("Value with track and before attach and AsNoTracking..");



            appDbContext.Entry(club).State = EntityState.Detached;

            Console.WriteLine("No tracked entity for Club,  before attach Entity state : " + appDbContext.Entry(club).State);
            club.Name = "newName";
            Console.WriteLine("No tracked entity for Club,  before attach and modified Entity state : " + appDbContext.Entry(club).State);



            appDbContext.Clubs.Attach(club);
            appDbContext.Entry(club).State = EntityState.Modified;
            Console.WriteLine("Attach entity for Club,  after attach and modified Entity state : " + appDbContext.Entry(club).State);
            appDbContext.SaveChanges();
            Console.WriteLine("Attach entity for Club,  after savechange and modified Entity state : " + appDbContext.Entry(club).State);

            // Value is only updated to the memory not in database. For updating value to the data base we have to change the state to Modified after attach variable.
            // appDbContext.Entry(club).State = EntityState.Modified;
            print("Value after attach..");

        }
    }
}
