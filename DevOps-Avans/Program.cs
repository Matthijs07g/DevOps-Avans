using Domain.Models.SprintModels;
using Services;

Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Release Sprint", DateTime.Now, DateTime.Now.AddDays(14));
Sprint reviewSprint = SprintFactory.CreateReviewSprint("Review Sprint", DateTime.Now, DateTime.Now.AddDays(14));

Console.WriteLine(releaseSprint.Name);
releaseSprint.Name = "Release Sprint naam aangepast";
Console.WriteLine(releaseSprint.Name);
releaseSprint.Start();
try
{
    releaseSprint.Name = "Release Sprint naam weer aangepast";
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
