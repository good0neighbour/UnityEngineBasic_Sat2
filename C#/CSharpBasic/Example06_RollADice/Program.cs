using System;

namespace Example06_RollADice
{
    internal class Program
    {
        static int dice = 20;
        static int pos = 0;
        static int move = 0;
        static int score = 0;
        static int size = 20;
        static void Main(string[] args)
        {
            Random rand = new Random();
            TileMap map = new TileMap();
            map.MapSetUp(size);
            while (dice > 0)
            {
                Console.WriteLine("엔터를 눌러 주사위 굴리기.");
                Console.ReadLine();
                dice--;
                move = rand.Next(1, 6);
                DiceShape(move);
                EarnStarValue(map);
                if (map.TryGetTileInfo(pos, out TileInfo tileInfo))
                {
                    tileInfo.OnTile();
                }
                else
                {
                    throw new Exception("플레이어가 맵을 이탈했습니다.");
                }
                Console.WriteLine($"현재 샛별점수 : {score}");
                Console.WriteLine($"남은 주사위 개수 : {dice}");
            }
            Console.WriteLine($"게임 끝. 총 샛별 점수 : {score}");
        }
        static private void EarnStarValue(TileMap map)
        {
            int starPassed = (pos + move) / 5 - pos / 5;
            pos += move;
            for (int i = 0; i < starPassed; i++)
            {
                int index = (pos / 5 - i) * 5;
                if (index > size)
                    index -= size;
                if (map.TryGetTileInfo(index, out TileInfo tileInfo_Star))
                {
                    score += (tileInfo_Star as TileInfo_Star).starValue;
                }
                else
                {
                    throw new Exception("샛별 칸 정보를 가져오는데 실패했습니다.");
                }
            }
            if (pos > size)
                pos -= size;
        }
        static private void DiceShape(int move)
        {
            switch (move)
            {
                case 1:
                    Console.WriteLine("┌-------------┐");
                    Console.WriteLine("|              |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("|      ●      |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("└-------------┘");
                    break;
                case 2:
                    Console.WriteLine("┌-------------┐");
                    Console.WriteLine("| ●           |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("|           ● |");
                    Console.WriteLine("└-------------┘");
                    break;
                case 3:
                    Console.WriteLine("┌-------------┐");
                    Console.WriteLine("| ●           |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("|      ●      |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("|           ● |");
                    Console.WriteLine("└-------------┘");
                    break;
                case 4:
                    Console.WriteLine("┌-------------┐");
                    Console.WriteLine("| ●        ● |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("| ●        ● |");
                    Console.WriteLine("└-------------┘");
                    break;
                case 5:
                    Console.WriteLine("┌-------------┐");
                    Console.WriteLine("| ●        ● |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("|      ●      |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("| ●        ● |");
                    Console.WriteLine("└-------------┘");
                    break;
                case 6:
                    Console.WriteLine("┌-------------┐");
                    Console.WriteLine("| ●        ● |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("| ●        ● |");
                    Console.WriteLine("|              |");
                    Console.WriteLine("| ●        ● |");
                    Console.WriteLine("└-------------┘");
                    break;
                default:
                    break;
            }
        }
    }
}
