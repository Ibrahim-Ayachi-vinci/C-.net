// See https://aka.ms/new-console-template for more information
using System.Collections;
using LINQDataContext;

class Program
{
    static void Main(string[] args)
    {
        DataContext dc = new DataContext();

        Student? jdepp = (from student in dc.Students
                          where student.Login == "jdepp"
                          select student).SingleOrDefault();

        if (jdepp != null)
        {
            Console.WriteLine(jdepp.Last_Name + " " + jdepp.First_Name);
        }
        else
        {
            Console.WriteLine("Student Not found");
        }



        ////////////////////////////////////////////
        ///r Exercice 2.2


        var QueryResult2_2 = from student in dc.Students
                             select new
                             {
                                 Request = student.Last_Name + " " + student.First_Name + " " + student.Student_ID + " " + student.BirthDate
                             };

        Console.WriteLine("--------------------------------------- Exercice 2.2 ---------------------------------------");

        foreach (var result in QueryResult2_2)
        {
            Console.WriteLine(result.Request);
        }



        //////////////////////////////////////////////
        /// Exerice 3.1



        var QueryResult3_1 = from student in dc.Students
                             where student.BirthDate.Year < 1995
                             select new
                             {
                                 Nom = student.Last_Name,
                                 Resultat_annuel = student.Year_Result,
                                 Statut = (student.Year_Result >= 12 ? "Ok" : "Ko")

                             };

        Console.WriteLine("--------------------------------------- Exercice 3.1 ---------------------------------------");

        foreach (var result in QueryResult3_1)
        {
            Console.WriteLine(result.Nom + " " + result.Resultat_annuel + " " + result.Statut);
        }






        //////////////////////////////////////////////
        /// Exerice 3.4

        var QueryResult3_4 = from student in dc.Students
                             where student.Year_Result <= 3
                             orderby student.Year_Result descending
                             select new
                             {
                                 Request = student.Last_Name + " " + student.Year_Result
                             };


        Console.WriteLine("--------------------------------------- Exercice 3.4 ---------------------------------------");

        foreach (var result in QueryResult3_4)
        {
            Console.WriteLine(result.Request);
        }



        //////////////////////////////////////////////
        /// Exerice 3.5


        var QueryResult3_5 = from student in dc.Students
                             where student.Section_ID == 1110
                             orderby student.Year_Result ascending
                             select new
                             {
                                 Request = student.Last_Name + " " + student.First_Name + " : " + student.Year_Result
                             };

        Console.WriteLine("--------------------------------------- Exercice 3.5 ---------------------------------------");


        foreach (var result in QueryResult3_5)
        {
            Console.WriteLine(result.Request);
        }



        //////////////////////////////////////////////
        /// Exerice 4.1
        /// 





        Console.WriteLine("--------------------------------------- Exercice 4.1 ---------------------------------------");

        Console.WriteLine("Resultat annuel moyen : " + dc.Students.Average(st => st.Year_Result));


        //////////////////////////////////////////////
        /// Exerice 4.5
        /// 





        Console.WriteLine("--------------------------------------- Exercice 4.5 ---------------------------------------");

        Console.WriteLine("Nombre de ligns qui composent la table students " + dc.Students.Count());







        //////////////////////////////////////////////
        /// Exerice 5.1
        /// 



        IEnumerable<IGrouping<int, Student>> QueryResult5_1 =
            from student in dc.Students
            group student by student.Section_ID;



        Console.WriteLine("--------------------------------------- Exercice 5.1 ---------------------------------------");

        foreach(IGrouping<int, Student> g in QueryResult5_1)
        {
            Console.WriteLine("Resultat moyen pour la section " + g.Key + " est de " + g.Average(student => student.Year_Result));
        }


        //////////////////////////////////////////////
        /// Exerice 5.3
        /// 


        IEnumerable<IGrouping<int, Student>> QueryResult5_3 =
            from student in dc.Students
            where student.BirthDate.Year >=1970 && student.BirthDate.Year <= 1985
            group student by student.BirthDate.Month;



        Console.WriteLine("--------------------------------------- Exercice 5.3 ---------------------------------------");

        foreach(IGrouping<int, Student> g in QueryResult5_3)
        {
            Console.WriteLine("Résultat moyen pour les étudiant : " + g.Average(student => student.Year_Result) + " née le mois de : " + g.First().BirthDate.Month);
        }





        //////////////////////////////////////////////
        /// Exerice 5.5
        /// 


        var QueryResult5_5 = from cour in dc.Courses
                             join p in dc.Professors on cour.Professor_ID equals p.Professor_ID
                             join s in dc.Sections on p.Section_ID equals s.Section_ID
                             select new
                             {
                                 Course_name = cour.Course_Name,
                                 Section_name = s.Section_Name,
                                 Professor_name = p.Professor_Name
                             };


        Console.WriteLine("--------------------------------------- Exercice 5.5 ---------------------------------------");


        foreach(var g in QueryResult5_5)
        {
            Console.WriteLine("course name : " + g.Course_name + " Section Name : " + g.Section_name + " Professor Name : " + g.Professor_name);
        }


    }
}