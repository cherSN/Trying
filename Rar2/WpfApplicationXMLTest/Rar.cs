﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rar
{
    public class RarFile
    {
        public DateTime DocumentDate { set; get; }
        public string Version { set; get; }
        public string ProgramName { set; get; }
        public string FormNumber { set; get; }
        public string ReportPeriod { set; get; }
        public string YearReport { set; get; }
        public int CorrectionNumber { set; get; }
    }

    public class RarCompany
    {
        public string ID { set; get; }
        public bool Producter { set; get; }
        public string Name { set; get; }
        public string INN { set; get; }
        public string KPP { set; get; }
        public string CounryID { set; get; }
        public RarAdress Adress { set; get; }
        public List<RarLicense> LicensesList { set; get; }

        public RarCompany()
        {
            Adress = new RarAdress();
            LicensesList = new List<RarLicense>();
        }
    }

    public class RarSubdevision
    {
        public string Name { set; get; }
        public string KPP { set; get; }
        public RarAdress Adress { set; get; }
        public bool SalePresented { set; get; }
        public bool ReturnPresented { set; get; } 
        public RarSubdevision()
        {
            Adress = new RarAdress();
        }
    }

    public class RarOurCompany : RarCompany
    { 
        public RarFIO Director { set; get; }
        public RarFIO Accountant { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string UnLisenseActivity { set; get; }
        public List<RarSubdevision> SubdevisionList { set; get; }

        public RarOurCompany() : base()
        {
            Director = new RarFIO();
            Accountant = new RarFIO();
            SubdevisionList = new List<RarSubdevision>();
        }

    }

    public class RarFIO
    {
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Middlename { set; get; }

        public RarFIO() { }
        public RarFIO(string name, string surname, string middlename)
        {
            Name = name;
            Surname = surname;
            Middlename = middlename;
        }

    }

    public class RarAdress {
        public string CountryId { set; get; }
        public string PostCode { set; get; }
        public string RegionId { set; get; }
        public string District { set; get; }
        public string City { set; get; }
        public string Locality { set; get; }
        public string Street { set; get; }
        public string Building { set; get;}
        public string Block { set; get; }
        public string Litera { set; get; }
        public string Apartment { set; get; }

        public bool StrictAdress { set; get; }
        public string AdressString { set; get; }

        public RarAdress() { }
        public RarAdress(string adress)
        {
            StrictAdress = false;
            AdressString = adress;
        }

    }

    public class RarLicense
    {
//        public RarCompany Owner { set; get; }
        public string ID { set; get; }
        public string SeriesNumber { set; get; }
        public DateTime DateFrom { set; get; }
        public DateTime DateTo { set; get; }
        public string Issuer { set; get; }
        public string BusinesType { set; get; }
    }

    public class RarTurnoverData
    {
        public RarSubdevision Subdevision { set; get; }
        public string ProductionSortID { set; get; }
        public RarCompany Producter { set; get; }
        public RarCompany Buyer { set; get; }
        public RarLicense License { set; get; }
        public DateTime NotificationDate { set; get; }
        public string NotificationNumber { set; get; }
        public double NotificationTurnover { set; get; }
        public DateTime DocumentDate { set; get; }
        public string DocumentNumber { set; get; }
        public string CustomsDeclarationNumber { set; get; }
        public double Turnover { set; get; }

        public RarTurnoverData()
        {
            Subdevision = new RarSubdevision();
            Producter = new RarCompany();
            Buyer = new RarCompany();
            License = new RarLicense();

        }
    }
}

