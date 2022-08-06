using System;
using System.Threading;

//프로그램 시작 시
//말 다섯 마리를 만들고
//각 다섯 마리는 초당 10~20 (정수형) 범위 거리를 랜덤하게 움직임
//각각의 말이 거리 200에 도달하면 말의 이름과 등수를 출력해줌
//
//말은
//이름, 달린 거리를 멤버변수로
//달리기를 멤버함수로 가짐.
//달리기 멤버함수는 입력받은 거리를 달린 거리에 더해주어서 달린 거리를 누적시키는 역할을 함.
//
//매 초 달릴 때마다 각 말들이 얼마나 거리를 이동했는지 콘솔창에 출력해줌.
//경주가 끝나면 1, 2, 3, 4, 5,등 말의 이름을 등수 순서대로 콘솔창에 출력해줌.

namespace Example02_HorseRacing
{
    internal class Example02_HorseRacing
    {
        static int totalHorses = 5;
        static Random random;
        static int minSpeed = 1;
        static int maxSpeed = 2;
        static bool isFinished = false;
        static void Main(string[] args)
        {
            int[] rank = new int[totalHorses];
            int order = 0;
            int count = 1;
            Horse[] horses = new Horse[totalHorses];
            for (int i = 0; i < totalHorses; i++)
            {
                horses[i] = new Horse();
                horses[i].name = "말" + i;
                horses[i].distance = 0;
                horses[i].enabled = true;
            }
            Console.WriteLine("경주 시작!");
            while (!isFinished)
            {
                Console.WriteLine($"===================================== {count}초 경과 =====================================");
                random = new Random();
                for (int k = 0; k < 10; k++)
                {
                    for (int i = 0; i < totalHorses; i++)
                    {
                        if (horses[i].enabled)
                        {
                            int tmpMoveDistance = random.Next(minSpeed, maxSpeed + 1);
                            horses[i].Run(tmpMoveDistance);
                            if (horses[i].distance >= 200)
                            {
                                rank[order] = i;
                                order++;
                                horses[i].enabled = false;
                            }
                        }
                    }
                }
                for (int i = 0; i < totalHorses; i++)
                {
                    if (horses[i].enabled)
                    {
                        Console.WriteLine(horses[i].name + "\t달린 거리: " + horses[i].distance + "m");
                    }
                    else
                    {
                        Console.WriteLine(horses[i].name + "\t도착");
                    }
                }
                Console.Write("\n");
                if (order >= totalHorses)
                {
                    isFinished = true;
                    Console.WriteLine("경주 끝!\n");
                    break;
                }
                count++;
                Thread.Sleep(1000);
            }
            Console.WriteLine("착순표");
            for (int i = 0; i < totalHorses; i++)
            {
                Console.WriteLine(i+1 + "등\t" + horses[rank[i]].name);
            }
        }
    }

    public class Horse
    {
        public string name;
        public int distance;
        public bool enabled;

        public void Run(int moveDistance)
        {
            distance += moveDistance;
        }
    }
}
