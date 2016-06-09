﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citadels.App
{
    public class HelpCommand : IConsoleCommand
    {
        public string Title { get { return "Справка по игре"; } }
        public char Symbol { get { return 'H'; } }

        public void Execute()
        {
            Console.WriteLine();
            Console.WriteLine(
@"         Консольная версия настольной игры ""Цитадели"".
Правила игры:
В игру могут играть от двух до шести человек. 
Цель игры - заработать как можно больше очков за построенные кварталы.
Побеждает тот, у кого будет наибольшее количество очков, когда любой из игроков построит восемь кварталов.
Игра состоит из раундов, в каждом раунде:
  1) игроки сперва распределяют персонажей, которые определяют очередность ходов в раунде
  2) затем в свой ход каждый игрок:
    2.а) выполняет действие: берёт 2 монеты из банка или карты кварталов из колоды (одну из них надо вернуть в сброс);
    2.б) строит квартал в своём городе, постройка квартала является необязательной.

Для того, чтобы начать игру, нажмите S.
Для выхода из приложения нажмите Q.");
            Console.WriteLine();
        }
    }
}