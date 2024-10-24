// See https://aka.ms/new-console-template for more information

using SchoolApp.Models;
using SchoolApp.Repository;


SchoolContext schoolContext = new SchoolContext();
BaseRepositorySQL<Section> repoSection = new BaseRepositorySQL<Section>(schoolContext);

var sectInfo = new Section { Name = "sectInfo" };
var sectDiet = new Section { Name = "sectDiet" };

Console.WriteLine("Ajout des sections ");

repoSection.Insert(sectInfo);
repoSection.Insert(sectDiet);

foreach (Section section in repoSection.GetAll())
{
    Console.WriteLine(section.Name);
}