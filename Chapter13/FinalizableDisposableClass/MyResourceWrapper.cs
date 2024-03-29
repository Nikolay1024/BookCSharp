﻿using System;

namespace FinalizableDisposableClass
{
    // Усовершенствованная оболочка для ресурсов.
    public class MyResourceWrapper : IDisposable
    {
        // Сборщик мусора будет вызывать этот метод, если
        // пользователь объекта забыл вызвать Dispose().
        ~MyResourceWrapper()
        {
            // Очистить неуправляемые ресурсы.
        }
        // Пользователь объекта будет вызывать этот метод
        // для как можно более скорой очистки ресурсов.
        public void Dispose()
        {
            // Очистить неуправляемые ресурсы.
            // Вызвать Dispose() для неуправляемые объектов,
            // содержащихся внутри.
            // Если пользователь вызвал Dispose(), то финализация
            // не нужна, поэтому подавить ее.
            GC.SuppressFinalize(this);
        }
    }
}
