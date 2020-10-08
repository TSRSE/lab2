﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab2_DB
{
    /*
1 Саяпов Олег Евгениевич 13.10.02 ИТАСУ БПИ20-9 1 4
2 Иванов Иван Иванович 01.07.03 ИТАСУ БПИ20-9 1 4,2
3 Алексей Истомин Иванович 02.08.01 ИТАСУ БПИ20-9 1 4,2
     */
    // 1 Иванов Иван Иванович **.**.** [Институт] [группа] [Курс] *,*
    class Student
    {
        public int PlaceInList { get; set; }            // 1
        public string SurName { get; set; }             // Иванов
        public string Name { get; set; }                // Иван
        public string MiddleName { get; set; }          // Иванович
        public string BirthDayDate { get; set; }        // **.**.**
        public string Institute { get; set; }           // [Институт]
        public string Group { get; set; }               // [группа]
        public int Cource { get; set; }                 // [Курс]
        public double AverageScore { get; set; }        // *,*

        public Student(int _placeinlist, string _surname, string _name, string _middlename, string _birthdate, string _institute, string _group, int _cource, double _avgscore) //КоНсТрУкТоР
        {
            PlaceInList = _placeinlist;
            SurName = _surname;
            Name = _name;
            MiddleName=_middlename;
            BirthDayDate=_birthdate;
            Institute=_institute;
            Group=_group;
            Cource=_cource;
            AverageScore = _avgscore;
        }
    }
}
