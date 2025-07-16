using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EloksalPro.Repositories
{
   public  class ClientCardRepository: BaseRepo<ClientCard>, IClientCardRepository
    {
        public void ClientCardUpdate(int id, string ClientNo, string ClientName, DateTime? date, string PhysicalAddress,
                                  string ContactPerson,  string ContactNumberPhone, string ContactEmail,string Manager)
                                 
        {

            var myEntity = Table.FirstOrDefault(e => e.Id == id);
            if (myEntity != null)
            {
                myEntity.ContractNumber = ClientNo;
                myEntity.ClientName = ClientName;
                myEntity.DateContract = date;
                myEntity.PhysicalAddress = PhysicalAddress;
                myEntity.ContactPerson = ContactPerson;
                myEntity.ContactNumberPhone = ContactNumberPhone;
                myEntity.ContactEmail = ContactEmail;
                myEntity.Manager = Manager;
                Context.SaveChanges();
                MessageBox.Show("Данные успешно изменены");
            }
        }
        public List<string> GetByExaminationNomenclature()
        {
            List<string> list = new List<string>();
            list = Table.Select(p => p.ClientName).ToList();
            return list;
        }
        public int GetByExaminationNomenclature(string name)
        {
            
            var list = Table.FirstOrDefault(p=>p.ClientName==name);
            if (list != null)
            {
                int idClientCard = list.Id;
                return idClientCard;
            }
            else
            {
                return 0;
            }
    
        }
        public string GetByNumberContract(string name)
        {

            var list = Table.FirstOrDefault(p => p.ClientName == name);
            if (list != null)
            {
                string idClientCard = list.ContractNumber;
                return idClientCard;
            }
            else
            {
                return string.Empty;
            }

        }
        public DateTime? GetByDateContract(string name)
        {

            var list = Table.FirstOrDefault(p => p.ClientName == name);
            if (list != null)
            {
                DateTime? dateCard = list.DateContract;
                return dateCard;
            }
            else
            {
                return null;
            }

        }

    }
}
