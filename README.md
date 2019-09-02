# Witness Visualizer
Edit and visualize irregular game panels for The Witness.

![image](https://github.com/instr3/WitnessVisualizer/raw/master/Screenshots/1.png)

![image](https://github.com/instr3/WitnessVisualizer/raw/master/Screenshots/2.jpg)

## Build Environment
.NET Framework 4.7.2

## How To Run
1. Build TemplateGenerator and WitnessVisualizer
2. Run TemplateGenerator.exe to automatically generate some templates.
3. Run WitnessVisualizer.exe, open the templates and edit them.

## How to add new Decorators
Decorators mean some symbols that are shown on the puzzle's faces/edges/corners. If you want to add a new mechanic (thus need a new symbol) to the puzzles, you can create your own decorator. Two examples in this project are ``RingDecorator`` and ``CircleDecorator`` that do not belong to the original game.
1. Add and implement a new decorator class in ``PuzzleGraph\Decorators``. See other implemented decorators for reference.
2. Add a ``XmlInclude(typeof(YourDecoratorClass))`` attribute to ``PuzzleGraph\Decorator.cs`` so it can be (de-)serialized when saving/loading the puzzle.
3. Implement the rendering method of the decorator in ``WitnessVisualizer\PuzzleGraphRenderer.cs``.
4. Add a new ``PuzzleToolkitDecoratorItem`` item in ``WitnessVisualizer\PuzzleToolkit.cs`` so that you can find one in the list view on the left of the editor.

## Project Structure
1. PuzzleGraph provides a uniform graph structure for storing irregular game panels. It supports Serialization & Deserialization from XML.
2. MathHelper provides some basic analytical functions.
3. WitnessVisualizer implements the main editor form and the rendering functions.
4. TemplateGenerator is an ugly program to generate some common templates for The Witness puzzles.

## Issues
1. WitnessVisualizer currently does not support adding/modifying graph nodes/edges/faces.
2. Hollow tetris will sometimes add random fragments due to unknown bugs of the WinForm drawing system.
