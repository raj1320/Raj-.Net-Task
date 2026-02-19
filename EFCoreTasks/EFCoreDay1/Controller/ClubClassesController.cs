using EFCoreDay1.Data;
using EFCoreDay1.Entities;
using EFCoreDay1.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDay1.Controller
{
    public class ClubClassesController
    {
        public static void AddClubsController()
        {
            using(AppDbContext appDbContext = new AppDbContext())
            {
                            
                Clubs club = ClubClassServices.FetchInputForAddClubs();

                ClubClassServices.AttachBehaviourAndLogging(appDbContext,club);

            }
        }
    }
}
