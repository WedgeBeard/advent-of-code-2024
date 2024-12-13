using Day01;
using Day02;
using Day03;
using Day04;
using Day05;
using Day06;
using Day07;
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
	[Export]
	private Button button_day_04_a;
	[Export]
	private Button button_day_04_b;
	[Export]
	private Button button_day_05_a;
	[Export]
	private Button button_day_05_b;
	[Export]
	private Button button_day_06_a;
	[Export]
	private Button button_day_06_b;
	[Export]
	private Button button_day_07_a;
	[Export]
	private Button button_day_07_b;

	private string directory = Directory.GetCurrentDirectory();

	public override void _Ready()
	{
		button_day_01_a.Pressed += RunDay01A;
		button_day_01_b.Pressed += RunDay01B;
		button_day_02_a.Pressed += RunDay02A;
		button_day_02_b.Pressed += RunDay02B;
		button_day_03_a.Pressed += RunDay03A;
		button_day_03_b.Pressed += RunDay03B;
		button_day_04_a.Pressed += RunDay04A;
		button_day_04_b.Pressed += RunDay04B;
		button_day_05_a.Pressed += RunDay05A;
		button_day_05_b.Pressed += RunDay05B;
		button_day_06_a.Pressed += RunDay06A;
		button_day_07_a.Pressed += RunDay07A;
		button_day_07_b.Pressed += RunDay07B;

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

	private void RunDay04A() {
		Day04A day04a = new Day04A();
		day04a.ComputeDay04A(directory);
	}

	private void RunDay04B() {
		Day04B day04b = new Day04B();
		day04b.ComputeDay04B(directory);
	}
	
	private void RunDay05A() {
		Day05A day05a = new Day05A();
		day05a.ComputeDay05A(directory);
	}

	private void RunDay05B() {
		Day05B day05b = new Day05B();
		day05b.ComputeDay05B(directory);
	}

	private void RunDay06A() {
		Day06A day06a = new Day06A();
		day06a.ComputeDay06A(directory);
	}

	private void RunDay06B() {
		Day06B day06b = new Day06B();
		day06b.ComputeDay06B(directory);
	}

	private void RunDay07A() {
		Day07A day07a = new Day07A();
		day07a.ComputeDay07A(directory);
	}

	private void RunDay07B() {
		Day07B day07b = new Day07B();
		day07b.ComputeDay07B(directory);
	}

}
