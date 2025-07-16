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
    public class SpecificationEloksalProfileRepository : BaseRepo<SpecificationEloksalProfile>, ISpecificationEloksalProfileRepository
    {
        public List<string> GetListNumberSpecification()
        {
            List<string> list = Table.Where(p => p.DatePlan == null || p.DatePlan == DateTime.MinValue).Select(p => p.NumberSpecification).ToList();
            return list;
        }

        public List<SpecificationEloksalProfile> GetListSpecifications()
        {
            List<SpecificationEloksalProfile> list = Table.Where(p => p.CalculateLabel==false).ToList();
            return list;
        }
        public int MaxNumberSpecification()
        {
            //if (DateTime.Now.ToString("dd") != "01" )
            //{
            List<SpecificationEloksalProfile> list = GetByAllEntity();

            if (list.Count() > 0)
            {
                int eloksalNoIntMax = 0;
                List<string> numberList = list.Where(p => p.DateSpecification.ToString("MMMM") == DateTime.Now.ToString("MMMM")).Select(p => p.NumberSpecification).ToList();
                List<int> eloksalNoListInt = new List<int>();

                foreach (string item in numberList)
                {
                    int ind = item.Length - 4;
                    // вырезаем последний символ
                    string text = item.Remove(ind);
                    int textNum = Convert.ToInt32(text);
                    eloksalNoListInt.Add(textNum);
                }
                if (numberList.Count>0)
                {
                    eloksalNoIntMax = eloksalNoListInt.Max();
                    return eloksalNoIntMax;
                }
                else
                {
                    return 0;
                }
            
            }
            else
            {
                return 0;
            }
        
    
            //else
            //{
            //    return 0;
            //}
        }
        public bool CheckValueNumberSpecification(string checkNumberSpecification)
        {
            bool checkValue = Table.Any(p => p.NumberSpecification== checkNumberSpecification);
            return checkValue;
        }
        public List<SpecificationEloksalProfileDif> ChangeDifData()
        {
            SpecificationAllDescriptionRepository reposDescriptionRepositoty = new SpecificationAllDescriptionRepository();
            List <DifferenceDataAll> difList = reposDescriptionRepositoty.DifferenceData();
            List <SpecificationEloksalProfile> listSpecification = Table.ToList();
           var listUnion = from l1 in listSpecification
                                                             join l2 in difList on l1.NumberSpecification.Trim() equals l2.NumberSpecification.Trim() into temp
                                                             from lj in temp.DefaultIfEmpty()
                                                             select new SpecificationEloksalProfileDif
                                                             {
                                                                 Id=l1.Id,
                                                                 NumberSpecification = l1.NumberSpecification,
                                                                 NumberContract = l1.NumberContract,
                                                                 ClientName = l1.ClientName,
                                                                 DateContract = l1.DateContract,
                                                                 CalculateLabel=l1.CalculateLabel,
                                                                 DateSpecification = l1.DateSpecification,
                                                                 DifData = lj == null ? 0 : lj.LengthAmountDifference,
                                                                 Manager=l1.Manager
                                                             };
            List<SpecificationEloksalProfileDif> list = listUnion.AsEnumerable().ToList();
            return list;
        }
        public void UpdateSpecification(int id, string numContract, DateTime dateSpecification)
        {
            SpecificationEloksalProfile myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.NumberSpecification = numContract;
                myEntity.DateSpecification = dateSpecification;
                Context.SaveChanges();
            }
        }
        public void UpdateDataPlanSpecification(string numberSpecification, DateTime? datePlan, double? massa)
        {
            SpecificationEloksalProfile myEntity = Table.FirstOrDefault(p => p.NumberSpecification == numberSpecification);
            if (myEntity != null)
            {
                myEntity.DatePlan = datePlan;
                myEntity.GeneralWeight = massa;
                Context.SaveChanges();
            }
        }
        public SpecificationEloksalProfile GetSpecificationEloksalProfile(string numberSpecification)
        {
            SpecificationEloksalProfile entity= new SpecificationEloksalProfile();
            entity = Table.FirstOrDefault(p => p.NumberSpecification == numberSpecification);
            return entity;
        }

        public List<SpecificationDataPlan> GetSpecificationDataPlan()
        {
            List<SpecificationDataPlan> list = new List<SpecificationDataPlan>();
            list = Table.Where(p => p.DatePlan != null && p.GeneralWeight != null).Select(g =>
                    new SpecificationDataPlan
                    {
                        ClientName = g.ClientName,
                        NumberSpecification = g.NumberSpecification,
                        GeneralWeight = g.GeneralWeight,
                        DatePlan = g.DatePlan
                    }).ToList();
            return list;
        }
    }
}
