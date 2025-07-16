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
    public class ReceptionMaterialsRepository : BaseRepo<ReceptionMaterials>, IReceptionMaterialsRepository
    {
        public bool CheckValueNumberSpecification(string checkNumberSpecification)
        {
            bool checkValue = Table.Any(p => p.NumberSpecification == checkNumberSpecification);
            return checkValue;
        }
        public void UpdateReceptionMaterials(int id, DateTime date, string shift, string userName, string annotation, double massa)
        {
            ReceptionMaterials myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.DateReception = date;
                myEntity.WorkingShift = shift;
                myEntity.FullName = userName;
                myEntity.Annotation = annotation;
                myEntity.TotalSumWeight = massa;
                Context.SaveChanges();
            }
        }
        public void UpdateReceptionMaterials(string num, double massa)
        {
            ReceptionMaterials myEntity = Table.FirstOrDefault(p => p.NumberSpecification == num);
            if (myEntity != null)
            {
                myEntity.TotalSumWeight = massa;
                Context.SaveChanges();
            }
        }
        public void UpdateReceptionMaterials(int id, string numSpecification)
        {
            ReceptionMaterials myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.NumberSpecification = numSpecification;
                Context.SaveChanges();
            }
        }
        public void UpdateReceptionMaterialsWeight(string numSpecification,double weight)
        {
            ReceptionMaterials myEntity = Table.FirstOrDefault(p => p.NumberSpecification == numSpecification);
            if (myEntity != null)
            {
                myEntity.WeightShippedProduction = weight;
                Context.SaveChanges();
            }
        }
       
        public double GetWeightShippedProduction(string numSpecification)
        {
            ReceptionMaterials myEntity = Table.FirstOrDefault(p => p.NumberSpecification == numSpecification);
            double weight=0;
            if (myEntity != null)
            {
                weight = myEntity.WeightShippedProduction;
            }
            return weight;
        }
        public double GetTotalSumWeight(string numSpecification)
        {
            ReceptionMaterials myEntity = Table.FirstOrDefault(p => p.NumberSpecification == numSpecification);
            double weight = 0;
            if (myEntity != null)
            {
                weight = myEntity.TotalSumWeight;
            }
            return weight;
        }
        public DateTime? DateReception(string numberSpecification)
        {
  
           var list = Table.FirstOrDefault(p => p.NumberSpecification == numberSpecification);
            DateTime? date=null;
            if (list != null)
            {
               date= list.DateReception;
            }
            return date;
        }
        public List<DateTime?> DateReception()
        {
            List<DateTime?> list = Table.Where(p=>p.DateReception!=null).Select(p=>p.DateReception).ToList();
            return list; 
        }

        public List<DateTime?> GetDifWeight()
        {
            List<DateTime?> list = Table.Where(p => p.DateReception != null).Select(p => p.DateReception).ToList();
            return list;
        }
    }
}