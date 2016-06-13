using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonShot
{
    enum TargetType
    {
        close_range_target,
        medium_range_target,
        high_range_target,
        strange_range_target
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTargets = 0;
            double range = 0;
            char selectedWeapon = '0', selectedAction = '0';
            HeavyCannon cannon1 = new HeavyCannon();
            ArtilleryBarrage barrage1 = new ArtilleryBarrage();
            Target tempTarget;
            TargetType targetDistance;
            Stack targets = new Stack();
            Console.WriteLine("Gra polega na strzelaniu do celu z dwóch różnych dział za pomocą konsoli");
            Console.WriteLine("Podaj liczbę celi");
            try
            {
                numberOfTargets = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Nieprawidłowy parametr");
            }

            for (int i = 0; i < numberOfTargets; i++)
            {
                tempTarget = new Target();
                targets.Push(tempTarget);
            }


            //strzelanie do kolejnych celi
            for (int i = 0; i < numberOfTargets; i++)
            {
                tempTarget = (Target)targets.Pop();
                if (tempTarget.XPosition <= 9)
                    targetDistance = TargetType.close_range_target;
                else if (tempTarget.XPosition > 9 && tempTarget.XPosition <= 11)
                    targetDistance = TargetType.medium_range_target;
                else if (tempTarget.XPosition > 11)
                    targetDistance = TargetType.high_range_target;
                else
                    targetDistance = TargetType.strange_range_target;


                //niszczenie celu
                while (tempTarget.Health >= 0)
                {
                    Console.WriteLine("Dane celu:");
                    Console.WriteLine(targetDistance);
                    Console.WriteLine("odległość celu {0:f}", tempTarget.XPosition);

                    Console.WriteLine("Wybierz broń której chcesz użyć c - Heavy Cannon, b = Artillery Barrage");
                    selectedWeapon = char.Parse(Console.ReadLine());
                    if (selectedWeapon == 'c')
                    {

                        Console.WriteLine("Wciśnij r aby przełądować broń, wciśnij spację aby oddać strzał a następnie enter");
                        Console.WriteLine("Stan magazynka: {0:d}", cannon1.ClipSize);
                        selectedAction = char.Parse(Console.ReadLine());
                        if (selectedAction == 'r')
                        {
                            cannon1.Reload();
                        }
                        else if (selectedAction == ' ')
                        {
                            Console.WriteLine("Podaj kąt ostrzału i wciśnij enter aby oddać strzał");
                            cannon1.Aim = double.Parse(Console.ReadLine());
                            range = cannon1.Fire();
                            if (Math.Abs(tempTarget.XPosition - range) <= cannon1.Accuracy)
                            {
                                Console.WriteLine("Trafienie!");
                                if (tempTarget.Aromor != 0)
                                    tempTarget.Aromor = 0;
                                else
                                    tempTarget.Health -= cannon1.FirePower;

                                Console.WriteLine("Cel ma jeszcze {0:f} punktów życia!", tempTarget.Health);
                            }
                            else if (range == 0)
                            {
                                throw new System.Exception("GAME OVER - baza zostałą zniszczona");
                            }
                            else
                                Console.WriteLine("Pudło! Punkt ostrzału: {0:f}", range);
                        }
                        else
                            Console.WriteLine("Niepoprwany parametr");

                       
                    }
                    else if (selectedWeapon == 'b')
                    {
                        Console.WriteLine("Wciśnij r aby przełądować broń, wciśnij spację aby oddać strzał a następnie enter");
                        Console.WriteLine("Stan magazynka: {0:d}", barrage1.ClipSize);
                        selectedAction = char.Parse(Console.ReadLine());
                        if (selectedAction == 'r')
                        {
                            barrage1.Reload();
                        }
                        else if (selectedAction == ' ')
                        {
                            Console.WriteLine("Podaj prędkość pocisków i wciśnij enter aby oddać strzał");
                            barrage1.Aim = double.Parse(Console.ReadLine());
                            
                            for (int j = 0; i < 3; i++)
                            {
                                range = barrage1.Fire();
                                if (Math.Abs(tempTarget.XPosition - range) <= barrage1.Accuracy)
                                {
                                    Console.WriteLine("Trafienie!");
                                    if (tempTarget.Aromor != 0)
                                        tempTarget.Aromor = 0;
                                    else
                                        tempTarget.Health -= barrage1.FirePower;

                                    Console.WriteLine("Cel ma jeszcze {0:f} punktów życia!", tempTarget.Health);
                                }
                                else if (range == 0)
                                {
                                    throw new System.Exception("GAME OVER - baza zostałą zniszczona");
                                }
                                else
                                    Console.WriteLine("Pudło! Punkt ostrzału: {0:f}", range);
                            }
                            
                        }
                        else
                            Console.WriteLine("Niepoprwany parametr");

                    }
                    else
                        Console.WriteLine("Niepoprawny parametr");

                }
            }
        }
    }
}
