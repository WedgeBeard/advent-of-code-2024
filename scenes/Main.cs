using Day01;
using Day02;
using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class Main : Node2D
{
	[Export]
	private Button button_day_01_a;

	[Export]
	private Button button_day_01_b;

	[Export]
	private Button button_day_02_a;

	[Export]
	private Button button_day_02_b;

	private string directory = Directory.GetCurrentDirectory();

	public override void _Ready()
	{
		button_day_01_a.Pressed += RunDay01A;
		button_day_01_b.Pressed += RunDay01B;
		button_day_02_a.Pressed += RunDay02A;
		button_day_02_b.Pressed += RunDay02B;
	}

	public override void _Process(double delta)
	{
	}

	private void RunDay01A() {
		Day01A day01a = new Day01A();
		day01a.ComputeDay01A(directory);
	}

	private void RunDay01B() {
		Day01B day01b = new Day01B();
		day01b.ComputeDay01B(directory);
	}
	
	private void RunDay02A() {
		Day02A day02a = new Day02A();
		day02a.ComputeDay02A(directory);
	}

	private void RunDay02B() {
		Day02B day02b = new Day02B();
		day02b.ComputeDay02B(directory);
	}
}
