using Infrastructure.Entities;

namespace Infrastructure.Seeds
{
    public class WorkerSeed
    {
        internal Worker[] Workers
        {
            get
            {
                return new Worker[]
                {
                    new Worker{PostName="Stenographer-Cum-Computer Operator",Id=11000001,User="11LQWESM",Name="MD ISRAFIL SORKER",FathersName="ABDUL BATEN SARKER",MothersName="SALINA AKTER",DateOfBirth=new DateTime(1992,2,22),PermanentDistrict="Munshiganj",Quota="Ansar-VDP" },
                    new Worker{ PostName="Stenographer-Cum-Computer Operator",Id=11000002,User="146DK6YZ",Name="SYFUL ISLAM",FathersName="MD. ABDUL GONI",MothersName="HASINA AKTHER",DateOfBirth=new DateTime(1993,2,10),PermanentDistrict="Kishorganj",Quota="Physically Handicapped"  },
                    new Worker{ PostName="Stenographer-Cum-Computer Operator",Id=11000003,User="16ZHEPC4",Name="SUJAN",FathersName="MD ALIMUDDIN MOLLA",MothersName="SEFALI BEGUM",DateOfBirth=new DateTime(1996,10,6),PermanentDistrict="Rajbari",Quota="Non Quota"  },
                    new Worker{ PostName="Stenographer-Cum-Computer Operator ",Id=11000004,User="1718Q6MA",Name="SUBARNA AKHTER",FathersName="MD. ENAMUL HAQUE KHAN",MothersName="RINA BEGUM",DateOfBirth=new DateTime(1994,6,8),PermanentDistrict="Gopalganj",Quota="Non Quota" },
                    new Worker{  PostName="Stenographer-Cum-Computer Operator ",Id=11000005,User="17NUT467",Name="LUTFOR RAHMAN",FathersName="LIAKOT ALI",MothersName="RASIDA BEGUM",DateOfBirth=new DateTime(1991,7,29),PermanentDistrict=" Rajbari",Quota="Ansar-VDP"  },
                    new Worker{ PostName="Stenographer-Cum-Computer Operator ",Id=11000006,User="1BATJVHD",Name="MOST. MAHBUBA KHANOM",FathersName="MD. NAOSHADUL HAQUE",MothersName="MOST. KHALEDA BIBI",DateOfBirth=new DateTime(1991,7,10),PermanentDistrict="Naogaon",Quota="Non Quota"  },
                    new Worker{ PostName="Stenographer-Cum-Computer Operator ",Id=11000007,User="1F26E9FU",Name="KRISHNO KUMAR SARKAR",FathersName="NARAYAN CHANDRA SARKAR",MothersName="NANDA RANI SARKAR",DateOfBirth=new DateTime(1992,12,30),PermanentDistrict="Bogura",Quota="Non Quota" },
                    new Worker{ PostName="Stenographer-Cum-Computer Operator ",Id=11000008,User="1EV6P37Z",Name="PROSENJIT KUMAR DAS",FathersName="NARAYAN KUMAR DAS",MothersName="BASONA RANI DAS",DateOfBirth=new DateTime(1992,8,28),PermanentDistrict="Khulna",Quota="Non Quota"  },
                    new Worker{ PostName="Stenographer-Cum-Computer Operator ",Id=11000009,User="11LQWESM",Name="MD. TAREK AZIZ",FathersName="MD. MOYEN UDDIN",MothersName="SHUKHZAN KHATUN",DateOfBirth=new DateTime(1990,9,21),PermanentDistrict="Kushtia",Quota="Child of Freedom Fighter"  },
                    new Worker{ PostName="Stenographer-Cum-Computer Operator ",Id=11000010,User="1JXCS1TV",Name="ANOUP KUNDO",FathersName="MONORANJAN KUNDO",MothersName="ANJANA KUNDO",DateOfBirth=new DateTime(1990,11,20),PermanentDistrict="Manikganj",Quota="Non Quota" }
                };
            }
        }
    }
}