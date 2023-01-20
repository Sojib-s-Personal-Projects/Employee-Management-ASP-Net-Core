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
                    new Worker{ Id = new Guid("13530E69-AEB3-4A44-B6A0-714546093FE7"), PostName="Stenographer-Cum-Computer Operator",Roll=11000001,User="11LQWESM",Name="MD ISRAFIL SORKER",FathersName="ABDUL BATEN SARKER",MothersName="SALINA AKTER",DateOfBirth=new DateTime(1992,2,22),PermanentDistrict="Munshiganj",Quota="Ansar-VDP" },
                    new Worker{ Id = new Guid("2FA3A5D2-C1F9-48A8-9CE4-CC05C3B739AE"), PostName="Stenographer-Cum-Computer Operator",Roll=11000002,User="146DK6YZ",Name="SYFUL ISLAM",FathersName="MD. ABDUL GONI",MothersName="HASINA AKTHER",DateOfBirth=new DateTime(1993,2,10),PermanentDistrict="Kishorganj",Quota="Physically Handicapped"  },
                    new Worker{ Id = new Guid("9FC6ABEA-0D6D-4168-B147-549F2A64A174"), PostName="Stenographer-Cum-Computer Operator",Roll=11000003,User="16ZHEPC4",Name="SUJAN",FathersName="MD ALIMUDDIN MOLLA",MothersName="SEFALI BEGUM",DateOfBirth=new DateTime(1996,10,6),PermanentDistrict="Rajbari",Quota="Non Quota"  },
                    new Worker{ Id = new Guid("DA27FB57-9979-4ECC-BAAA-D329663D84C4"), PostName="Stenographer-Cum-Computer Operator ",Roll=11000004,User="1718Q6MA",Name="SUBARNA AKHTER",FathersName="MD. ENAMUL HAQUE KHAN",MothersName="RINA BEGUM",DateOfBirth=new DateTime(1994,6,8),PermanentDistrict="Gopalganj",Quota="Non Quota" },
                    new Worker{ Id = new Guid("13BDC36D-4439-4973-86BD-3297EA07B83D"), PostName="Stenographer-Cum-Computer Operator ",Roll=11000005,User="17NUT467",Name="LUTFOR RAHMAN",FathersName="LIAKOT ALI",MothersName="RASIDA BEGUM",DateOfBirth=new DateTime(1991,7,29),PermanentDistrict=" Rajbari",Quota="Ansar-VDP"  },
                    new Worker{ Id = new Guid("28923949-C440-42E5-A0CE-D223CA37B09C"), PostName="Stenographer-Cum-Computer Operator ",Roll=11000006,User="1BATJVHD",Name="MOST. MAHBUBA KHANOM",FathersName="MD. NAOSHADUL HAQUE",MothersName="MOST. KHALEDA BIBI",DateOfBirth=new DateTime(1991,7,10),PermanentDistrict="Naogaon",Quota="Non Quota"  },
                    new Worker{ Id = new Guid("F0C01180-6812-408D-AC9F-F062AFD88B42"), PostName="Stenographer-Cum-Computer Operator ",Roll=11000007,User="1F26E9FU",Name="KRISHNO KUMAR SARKAR",FathersName="NARAYAN CHANDRA SARKAR",MothersName="NANDA RANI SARKAR",DateOfBirth=new DateTime(1992,12,30),PermanentDistrict="Bogura",Quota="Non Quota" },
                    new Worker{ Id = new Guid("84B84D3F-6502-4F0A-8987-AE0A25F851F0"), PostName="Stenographer-Cum-Computer Operator ",Roll=11000008,User="1EV6P37Z",Name="PROSENJIT KUMAR DAS",FathersName="NARAYAN KUMAR DAS",MothersName="BASONA RANI DAS",DateOfBirth=new DateTime(1992,8,28),PermanentDistrict="Khulna",Quota="Non Quota"  },
                    new Worker{ Id = new Guid("BE8FE95C-6556-4BC4-B0FE-D604485D1655"), PostName="Stenographer-Cum-Computer Operator ",Roll=11000009,User="11LQWESM",Name="MD. TAREK AZIZ",FathersName="MD. MOYEN UDDIN",MothersName="SHUKHZAN KHATUN",DateOfBirth=new DateTime(1990,9,21),PermanentDistrict="Kushtia",Quota="Child of Freedom Fighter"  },
                    new Worker{ Id = new Guid("C1B2E030-A264-4D50-814B-2BCBA273EFE0"), PostName="Stenographer-Cum-Computer Operator ",Roll=11000010,User="1JXCS1TV",Name="ANOUP KUNDO",FathersName="MONORANJAN KUNDO",MothersName="ANJANA KUNDO",DateOfBirth=new DateTime(1990,11,20),PermanentDistrict="Manikganj",Quota="Non Quota" }
                };
            }
        }
    }
}