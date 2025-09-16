# Taller de LINQ en C#
### Contexto del taller
Una universidad necesita gestionar información sobre sus estudiantes, cursos y matrículas.
Tu tarea es crear modelos en C#, inicializar colecciones con datos de ejemplo, y resolver los ejercicios usando LINQ.
Crear los modelos
Crea las siguientes clases:

```
public class Student
{
public int Id { get; set; }
public string Name { get; set; }
public int Age { get; set; }
}

public class Course
{
public int Id { get; set; }
public string Title { get; set; }
public int Credits { get; set; }
}

public class Enrollment
{
public int Id { get; set; }
public int StudentId { get; set; }
public int CourseId { get; set; }
public double Grade { get; set; }
}

```

Crear colecciones con objetos

En el Main, inicializa listas

Por lo menos tener 5 objetos por lista!

- Ejercicios con LINQ
- Ejercicio 1: Filtrar estudiantes mayores de 20 años
- Ejercicio 2: Ordenar cursos por créditos
- Ejercicio 3: Buscar un curso específico
- Ejercicio 4: Contar matrículas
- Ejercicio 5: Join entre matrículas y estudiantes
- Ejercicio 6: Join triple (estudiante + curso + matrícula)
- Ejercicio 8: Validaciones con LINQ (All, Any, Contains)