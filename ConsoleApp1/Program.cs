// See https://aka.ms/new-console-template for more information
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
    }
}