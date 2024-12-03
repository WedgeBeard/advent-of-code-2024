using Day01;
using Day02;
using Day03;
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
	[Export]
	private Button button_day_03_a;
	[Export]
	private Button button_day_03_b;

	private string directory = Directory.GetCurrentDirectory();

	public override void _Ready()
	{
		button_day_01_a.Pressed += RunDay01A;
		button_day_01_b.Pressed += RunDay01B;
		button_day_02_a.Pressed += RunDay02A;
		button_day_02_b.Pressed += RunDay02B;
		button_day_03_a.Pressed += RunDay03A;
		button_day_03_b.Pressed += RunDay03B;
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

	private void RunDay03A() {
		Day03A day03a = new Day03A();
		day03a.ComputeDay03A(directory);
	}

	private void RunDay03B() {
		Day03B day03b = new Day03B();
		day03b.ComputeDay03B(directory);
	}
}
