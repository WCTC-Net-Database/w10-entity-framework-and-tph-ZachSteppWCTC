﻿using Microsoft.EntityFrameworkCore;
using W9_assignment_template.Data;

namespace W9_assignment_template.Services;

public class Menu
{
    private readonly GameContext _gameContext;

    public Menu(GameContext gameContext)
    {
        _gameContext = gameContext;
    }

    public void Show()
    {
        while (true)
        {
            Console.WriteLine("1. Display Rooms");
            Console.WriteLine("2. Display Characters");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayRooms();
                    break;
                case "2":
                    DisplayCharacters();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    public void DisplayRooms()
    {
        var rooms = _gameContext.Rooms.Include(r => r.Characters).ToList();

        foreach (var room in rooms)
        {
            Console.WriteLine($"Room: {room.Name} - {room.Description}");
            foreach (var character in room.Characters)
            {
                Console.WriteLine($"    Character: {character.Name}, Level: {character.Level}");
            }
        }
    }

    public void DisplayCharacters()
    {
        var characters = _gameContext.Characters.ToList();
        if (characters.Any())
        {
            Console.WriteLine("\nCharacters:");
            foreach (var character in characters)
            {
                Console.WriteLine($"Character ID: {character.Id}, Name: {character.Name}, Level: {character.Level}, Room ID: {character.RoomId}");
                if (character.Abilities.Any())
                {
                    Console.WriteLine($"  {character.Name}'s Abilities:");
                    foreach (var ability in character.Abilities)
                    {
                        Console.WriteLine($"  Ability ID: {ability.Id}, Name: {ability.Name}, Desciption: {ability.Description}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("No characters available.");
        }
    }

}