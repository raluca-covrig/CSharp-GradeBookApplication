﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        ArrayList gradesArray = new ArrayList();
        public RankedGradeBook(string name, bool isWeighted):base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count<5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            ArrayList gradesArray = new ArrayList();
            foreach (Student s in Students)
                gradesArray.Add(s.AverageGrade);
            gradesArray.Sort();
            int studentsNumber = gradesArray.Count;
            if (averageGrade >= (double)gradesArray[4*studentsNumber / 5])
                return 'A';
            else if (averageGrade >= (double)gradesArray[3 * studentsNumber / 5])
                return 'B';
            if (averageGrade >= (double)gradesArray[2*studentsNumber / 5])
                return 'C';
            else if (averageGrade >= (double)gradesArray[1 * studentsNumber / 5])
                return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
