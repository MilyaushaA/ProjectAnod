using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
   public  class TechnicalSupportRepository:BaseRepo<TechnicalSupport>, ITechnicalSupportRepository
    {
        public List<TechnicalSupport> GetAllInventory()
        {
            List<TechnicalSupport> list = new List<TechnicalSupport>();
                var inventory = Table.ToList();
                list = new List<TechnicalSupport>(inventory);
                return list;
        }
        public void UpdateInventory(int id, DateTime? dateApp, DateTime? datePreliminaryReadiness, DateTime? dateReadiness, string applicationText, string customer)
        {
            TechnicalSupport empty = new TechnicalSupport();
                empty = Table.FirstOrDefault(p => p.Id == id);
                if (empty != null)
                {
                    empty.DateApp = dateApp;
                    empty.DatePreliminaryReadiness = datePreliminaryReadiness;
                    empty.DateReadiness = dateReadiness;
                    empty.ApplicationText = applicationText;
                    empty.Customer = customer;
                    Context.SaveChanges();
                }

            }
        }
    }

