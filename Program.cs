using System.Diagnostics.CodeAnalysis;
using practicaLinq.Models;

namespace practicaLinq;

public class Program
{
    public static void Main(string[] args)
    {
    
        // coleccion students
        var students = new List<Student>
        {
            new Student { id = 1, name = "Sara", lastname = "Vallejo", age = 28 },
            new Student { id = 2, name = "Davis", lastname = "Zapata", age = 22 },
            new Student { id = 3, name = "John", lastname = "Willis", age = 20 },
            new Student { id = 4, name = "Edd", lastname = "Rave", age = 19 },
            new Student { id = 5, name = "Anne", lastname = "Wenzel", age = 31 },
            new Student { id = 6, name = "Klauss", lastname = "Klauss", age = 32 },
        };
        
        
        // Colección de Courses:
        var courses = new List<Course>
        {
            new Course { id = 1, title = "Math", credits = 3 },
            new Course { id = 2, title = "Biology", credits = 3 },
            new Course { id = 3, title = "Calculus One", credits = 4 },
            new Course { id = 4, title = "Calculus Two", credits = 5 },
            new Course { id = 5, title = "Etics", credits = 2 },
            new Course { id = 6, title = "Physics", credits = 4 }
        };
        
        
        // Coleccion de Enrollments:
        var enrollments = new List<Enrollment>
        {
            new Enrollment { id = 1, studentId = 1, courseId = 2, grade = 80.1 },
            new Enrollment { id = 2, studentId = 2, courseId = 1, grade = 50.5 },
            new Enrollment { id = 3, studentId = 3, courseId = 4, grade = 78.3 },
            new Enrollment { id = 4, studentId = 3, courseId = 5, grade = 33.1 },
            new Enrollment { id = 5, studentId = 4, courseId = 5, grade = 20.9 },
            new Enrollment { id = 6, studentId = 5, courseId = 6, grade = 100.0 },
            new Enrollment { id = 7, studentId = 6, courseId = 3, grade = 97.5 }
        };
        
        
        // LINQ QUERIES:
        
        // Ejercicio 1: Filtrar estudiantes mayores de 20 años
        var query_E1 = from s in students
            where s.age > 20
            select s;
        foreach (var order in students)
        {
            Console.WriteLine($"La edad de {order.name} {order.lastname} es {order.age}");
        }

        Console.WriteLine("--------------------------------------");


        // Ejercicio 2: Ordenar cursos por créditos
        var query_E2 = from c in courses
            orderby c.credits ascending 
            select c;
        Console.WriteLine("Los cursos ordenamos por créditos son:");
        foreach (var order in query_E2)
        {
            Console.WriteLine($"{order.title}: {order.credits}");
        }

        Console.WriteLine("--------------------------------------");



        // Ejercicio 3: Buscar un curso específico
        var query_E3 = from c in courses
            where c.title == "Math"
            select c;

        //Console.WriteLine($"La materia buscada es: {}");
        foreach (var order in query_E3)
        {
            Console.WriteLine($"La materia buscada es: {order.title}");
        }

        Console.WriteLine("--------------------------------------");
        
        


        // Ejercicio 4: Contar matrículas
        var query_E4 = enrollments.Count();
        Console.WriteLine($"La cantidad de matriculas es: {query_E4}");

        Console.WriteLine("--------------------------------------");
        
        

        // Ejercicio 5: Join entre matrículas y estudiantes
        var query_E5 = from e in enrollments
            join s in students
                on e.studentId equals s.id
                orderby e.grade descending 
            select new { IdEst = e.studentId, 
                nombre_completo = s.name + " " + s.lastname,
                edad = s.age, 
                nota = e.grade
            };
        
        Console.WriteLine("Notas por estudiante:");
        
        foreach (var order in query_E5)
        {
            Console.WriteLine($"{order}");
        }

        
        Console.WriteLine("--------------------------------------");


        // Ejercicio 6: Join triple (estudiante + curso + matrícula)
        var query_E6 = from e in enrollments
            join s in students
                on e.studentId equals s.id
            join c in courses
                on e.courseId equals c.id
                orderby e.grade descending 
            select new
            {
                fullName = s.name + " " + s.lastname,
                s.age,
                c.title,
                e.grade
            };

        Console.WriteLine("Full Name       Age   Signature    Grade");
        
        foreach (var order in query_E6)
        {
            Console.WriteLine($"{order.fullName,-14} {order.age,3} {order.title,-15} {order.grade,5}");
        }
        
        Console.WriteLine("--------------------------------------");
        
        
        
        // Ejercicio 8: Validaciones con LINQ (All, Any, Contains)
        
        // 8.1) Validar si en el listado de estudiantes hay algún 'Diego'.
        var query_E8_1 = students.Select(s => s.name);
        bool nameValidation = query_E8_1.Contains("Diego");

        Console.WriteLine($"El listado de estudiantes tiene algún 'Diego' ?  R/ {nameValidation}"  );

        Console.WriteLine("--------------------------------------");
        
        
        
        // 8.2) ¿Hay algún estudiante mayor de 30 años?
        bool query_E8_2 = students.Any(s => s.age > 25);
        Console.WriteLine($"Hay algún estudiante mayor de 25 años?  R/ {query_E8_2}");
        
        Console.WriteLine("--------------------------------------");
        
        
        
        // 8.3) ¿Algún curso tiene más de 4 créditos?
        bool query_E8_3 = courses.Any(c => c.credits >= 6);
        Console.WriteLine($"Hay algún curso con 6 o mas creditos?  R/ {query_E8_3}");

        Console.WriteLine("--------------------------------------");
        
        
        
        // 8.4) ¿Algún estudiante se llama "Anne"?
        string searchedStudent = "Anne".ToLower();
        bool query_E8_4 = students.Any(s => s.name.ToLower() == searchedStudent);
        Console.WriteLine($"¿Algún estudiante se llama 'Anne' ?   R/ {query_E8_4}");
        
        Console.WriteLine("--------------------------------------");
        
        
        
        // 8.5) ¿Todos los estudiantes son mayores de 18?
        bool maj_18 = students.All(s => s.age >= 18);
        Console.WriteLine($"¿Todos los estudiantes son mayores de 18?  R/ {maj_18}");
        
        
        Console.WriteLine("--------------------------------------");
        
        // 8.6) ¿Todos los cursos tienen mas de 2 créditos?
        bool twoCredits = courses.All(c => c.credits > 2);
        Console.WriteLine($"¿Todos los cursos tienen al menos 2 créditos?  R/ {twoCredits}");
        
        
        
        Console.WriteLine("--------------------------------------");

        
        
        // 9) Mostrar las notas de las materias en las que esta matriculado cada estudiante. 
        // Mostrar también el fullname del estudiante con su respectiva nota para cada materia.
        
        var query_E9 = from e in enrollments
            join s in students
                on e.id equals s.id
            join c in courses
                on e.id equals c.id
            where s.name == "Sara" || s.name == "Edd" || s.name == "John"
            orderby e.grade descending
            select new
            {
                c.title, 
                fullName = s.name + " " + s.lastname, 
                e.grade
            };

        foreach (var order in query_E9)
        {
            Console.WriteLine($"{order.title,-12} {order.fullName,-18} {order.grade}");
        }



    }
}