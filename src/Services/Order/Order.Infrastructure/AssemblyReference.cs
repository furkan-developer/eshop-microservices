using System;
using System.Reflection;

namespace Order.Infrastructure;

public static class AssemblyReference
{
    public static Assembly Reference => typeof(AssemblyReference).Assembly;
}
