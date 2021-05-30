.assembly extern mscorlib
{	
	.publickeytoken = (B7 7A 5C 56 19 34 E0 89)
	.ver 4:0:0:0
}

// Наша сборка.
.assembly CILOpCodes
{
	.ver 1:0:0:0
}
// Модуль нашей однофайловой сборки.
.module CILOpCodes.dll

// Наша сборка имеет единственное пространство имен.
.namespace MyNamespace
{
	// Предполагается базовый класс System.Object.
	.class public MyBaseClass
	{
		// Определение обобщенных типов.
		.method public hidebysig static void DefineGenericTypes() cil managed
		{
			//В С#: List<int> list = new List<int>();
			newobj instance void class [mscorlib]
				System.Collections.Generic.List`1<int32>::.ctor()
			//В С#: Dictionary<string, int> dict = new Dictionary<string, int>();
			newobj instance void class [mscorlib]
				System.Collections.Generic.Dictionary`2<string,int32>::.ctor()
		}
		
		// Определение параметров.
		.method public hidebysig static void DefineParams(
			int32 valueInt, int32& refInt, [out] int32& outInt,
			class [mscorlib]System.Collections.ArrayList arr
			) cil managed
		{}
		
		// Определение максимальной глубины стека.
		.method public hidebysig static void MaxStack() cil managed
		{
			// Внутри области действия этого метода в стеке находится
			// в точности одно значение (строковый литерал).
			// По умолчанию maxstack 8.
			.maxstack 1
			// Загружает в стек строковое значение
			ldstr "Hello there..."
			// Вызов члена с параметром из стека
			call void [mscorlib]System.Console::WriteLine(string)
			// Выход из метода
			ret
		}
		
		// Определение локальных переменных.
		.method public hidebysig static void LocalVariables() cil managed
		{
			.maxstack 1
			// Определить три локальные переменные.
			.locals init ([0] string myStr, [1] int32 myInt, [2] object myObj)
			// Загрузить строку в виртуальный стек выполнения.
			ldstr "CIL code is fun!"
			// Извлечь текущее значение и сохранить его в локальной переменной [0].
			stloc.0
			// Загрузить константу типа I4 в стек со значением 33.
			ldc.i4 33
			// Извлечь текущее значение и сохранить его в локальной переменной [1].
			stloc.1
			// Создать новый объект и поместить его в стек.
			newobj instance void [mscorlib]System.Object::.ctor()
			// Извлечь текущее значение и сохранить его в локальной переменной [2].
			stloc.2
			ret
		}
		
		// Отображение параметров на локальные переменные в статическом методе.
		.method public hidebysig static int32 Add1(int32 a, int32 b) cil managed
		{
			.maxstack 2
			ldarg.0		// Загрузить а в стек.
			ldarg.1		// Загрузить b в стек.
			add 		// Сложить два верхних значения в стеке
						// и записать результат сложения обратно в стек.
			ret			// Выход из метода и возврат верхнего значения в стеке.
		}

		// Отображение параметров на локальные переменные в методе экземпляра.
		.method public hidebysig instance int32 Add2(int32 a, int32 b) cil managed
		{
			.maxstack 2
			ldarg.0		// Загрузить this в стек.
			ldarg.1		// Загрузить a в стек.
			ldarg.2		// Загрузить b в стек.
			add 		// Сложить два верхних значения в стеке
						// и записать результат сложения обратно в стек.
			ret			// Выход из метода и возврат верхнего значения в стеке.
		}

		// Итерационные конструкции в CIL
		.method public hidebysig static void Iteration() cil managed
		{
			.maxstack 2
			// Определить локальную переменную [0] типа int32 с именем i.
			.locals init ([0] int32 i)
			ldc.i4.0	// Загрузить константу 0 типа int32 в стек.
			stloc.0		// Сохранить значение из стека в локальную переменную [0].
			br.s m1		// Перейти на метку m1.
		m0:	ldloc.0		// Загрузить значение локальной переменной [0] в стек.
			ldc.i4.1	// Загрузить константу 1 типа int32 в стек.
			add			// Сложить два верхних значения в стеке
						// и записать результат сложения обратно в стек.
			stloc.0		// Сохранить значение из стека в локальную переменную [0].
		m1: ldloc.0		// Загрузить значение локальной переменной [0] в стек.
			ldc.i4.s 10	// Загрузить константу 10 типа int32 в стек.
			blt.s m0	// Если предпоследнее значение в стеке меньше чем
						// последнее (10), то перейти на метку m0.
			ret
		}
	}
}