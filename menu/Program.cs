using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace menu {
    enum Tasks {
        Task1,
        Task2,
        Task3,
        Task4,
        Task5,
        Task6

    }
    class Program {
        enum Lessons {
            Lesson1,
            Lesson2,
            Lesson3,
            Lesson4,
            ExempleLesson
        }
        
        enum Direction {
            dB_mV,
            mV_dB
        }
        static void Main(string[] args) {
            var lesson = Menu<Lessons>.GetSelectedInMenu(Menu<Lessons>.GetTypicalDictionaryForMenu("Урок"), "Выберите урок: ");
            var task = Menu<Tasks>.GetSelectedInMenu(Menu<Tasks>.GetTypicalDictionaryForMenu("Задание"), "Выберите задание: ");
            var directionDictionary = new Dictionary<Direction, string>() {
                {Direction.dB_mV,"дБ в мВ"},
                {Direction.mV_dB,"мВ в dB"}
            };
            var direction = Menu<Direction>.GetSelectedInMenu(directionDictionary, "Выберите направление преобразования: ");
        }
      
    }
}
