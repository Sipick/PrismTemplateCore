   M S B A M L   `   `   `  ����  ProjectControl&     ProjectControl.Views.ShellWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      S OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59N JPrism.DryIoc.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=null&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  True��5      .��5      �  � RowDefinitions 5   
   �� 5      -   5         ��Name$ 	RibbonRow��5	      $
��Auto �5
      �� 5      -   5        $ AppRow��5      $��* �5      �� 5      -   5        $ StatusBarRow��5      $��0.05* �5      .+�5   
   +  %System.Windows.Controls.Ribbon.Ribbon  $��0��5      
������ !  Prism.Regions.RegionManager   
RegionName$ RibbonTabRegion��5         ApplicationMenu 5      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5      $y�	Collapsed=�5      5      5      � 5   
   -   5         �Name$ 
ClientArea��5       $��1��5!       � ColumnDefinitions 5"      �� 5#      -   5         ��Name$ NavigationColumn��5$      $��0.200* �5%      �� 5&      -   5        $ WorkspaceColumn��5'      $��0.600* �5(      .+�5*      �� $
��Left=�5+      $��5��5,      $��1��5-      �� 5.      -   5         ��Name$ ProjectExplorerRegion��51      $��0��5/      $��0��50      $ ProjectExplorerRegion��52      �� 54      -   5        $ DisplayContentRegion��57      $��0��55      $��1��56      $ ContentRegion��58      59      �� 5;   
   -	   5        	 ��Name$	 	StatusBar��5=      $��2��5<      .@�5>      �� -
   5        
 ��Name$
 StatusBarProjectExplorer��5?      $ StatusBarRegion��5@      5A      5B      5C      