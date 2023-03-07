using Course;
using ActionsCourse;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var configuration = app.Configuration;

CourseMethods.Init(configuration);

app.MapPost("/register", (Student student) => {

    CourseMethods.Add(student);

    return Results.Created($"/register/{student.Id}", student.Name);
});

app.MapGet("/register/{id}", ([FromRoute] string id) => {
    var student = CourseMethods.SearchStudent(id);

    if (student != null)
        return Results.Ok(student);

    return Results.NotFound();
});

app.MapPut("/register", (Student student) => {

    var registeredStudent = CourseMethods.SearchStudent(student.Id);

    registeredStudent.Email = student.Email;

    return Results.Ok();
});

app.MapDelete("/register/{id}", ([FromRoute] string id) => {
    var studentData = CourseMethods.SearchStudent(id);

    CourseMethods.Delete(studentData);

    return Results.Ok();
});

app.MapGet("/configuration/database", (IConfiguration configuration) => {
    return Results.Ok($"{configuration["database:connection"]}/{configuration["database:Port"]}");
}); 

app.Run();