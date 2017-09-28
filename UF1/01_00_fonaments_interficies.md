[ ... back  ](../README.md)

# Temes introductoris d'Interfícies

## Contenidors bàsics


### StackPanel
Té un únic requisit: definir l'atribut *Orientation*, amb valors _Vertical_ o _Horizontal_.
Decidiu si el voleu horitzontal o vertical i els elements a dins s'apilen segons aquesta orientació.
```XML 
        <StackPanel Orientation="Vertical">
            <TextBox x:Name="txbLogin" PlaceholderText="Login"></TextBox>
            <TextBox x:Name="txbPassword" PlaceholderText="password"></TextBox>
            <Button x:Name="btnLogin" Content="Login" HorizontalAlignment="Stretch"></Button>
        </StackPanel>
```
		
### Grid

Les graelles permeten definir files i columnes usant *Grid.ColumnDefinitions* i *Grid.RowDefinitions*
Les mesures poden ser:
* en pixels ( un número simple )
* "percentuals", posant un asterisc precedit d'un pes en tant per 100 o qualsevol altre base ( 5*) 
* ajustat als continguts (auto)

```XML
    <Grid > 
        <Grid.ColumnDefinitions >
			<ColumnDefinition Width="auto"></ColumnDefinition>
            <ColumnDefinition Width="70*"></ColumnDefinition>
            <ColumnDefinition Width="30*"></ColumnDefinition>
			<ColumnDefinition Width="40"></ColumnDefinition>
        </Grid.ColumnDefinitions>
```

Per assignar un element a una casella de la graella, cal afegir un atribut _Grid.Column=""_ i/o _Grid.Row=""_
, i opcionalment podeu afegir _Grid.ColumnSpan=""_ i _Grid.RowSpan=""_ si voleu que l'element ocupi vàries columnes o vàries files respectivament.

    

### Programació dinàmica d'Events

```c#     
{
Button b = new Button();

b.Click += Button_Click; // assignem dimàmicament el mètode de gestió de l'event Click

}
private void Button_Click(object sender, RoutedEventArgs e)
{
	// event de click
}

```


### Estils bàsics

#### Definició d'un estil genèric per a botons

Fixeu-vos que es posa a Page.resources:
```XML
<Page.Resources>
    <Style TargetType="Button">
        <Setter Property="BorderThickness" Value="5" />
        <Setter Property="Foreground" Value="Black" />
        <Setter Property="BorderBrush" >
            <Setter.Value>
                <LinearGradientBrush StartPoint="0.5,0" EndPoint="0.5,1">
                    <GradientStop Color="Yellow" Offset="0.0" />
                    <GradientStop Color="Red" Offset="0.25" />
                    <GradientStop Color="Blue" Offset="0.75" />
                    <GradientStop Color="LimeGreen" Offset="1.0" />
                </LinearGradientBrush>
            </Setter.Value>
        </Setter>
    </Style>
</Page.Resources>
```

#### Definició d'un estil amb clau (x:Key):

```XML
    <Style x:Key="PurpleStyle" TargetType="Button">
        <Setter Property="FontFamily" Value="Segoe UI"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="Foreground" Value="Purple"/>
    </Style>
```

#### Aplicació de l'estil:

```XML
<Button Content="Button" Style="{StaticResource PurpleStyle}"/>
```

#### Herència d'estils:

Podem heredar l'atribut "BasedOn" per crear l'estil a partir d'una base.
```XML
    <Style x:Key="BasicStyle" TargetType="ContentControl">
        <Setter Property="Width" Value="130" />
        <Setter Property="Height" Value="30" />
    </Style>

    <Style x:Key="ButtonStyle" TargetType="Button"
           BasedOn="{StaticResource BasicStyle}">
        <Setter Property="BorderBrush" Value="Orange" />
        <Setter Property="BorderThickness" Value="2" />
        <Setter Property="Foreground" Value="Red" />
    </Style>
```

### TextBlocks i TextBox

Event TextChanged
Event KeyDown i KeyUp

### Diàlegs simples

```c#

	ContentDialog noWifiDialog = new ContentDialog
	{
		Title = "Atenció",
		Content = "Vol Sortir de l'aplicació el disc dur?",
		PrimaryButtonText = "Ok",
		SecondaryButtonText = "No",
	};

	ContentDialogResult result = await noWifiDialog.ShowAsync();
	if(result==ContentDialogResult.Primary)
	{
		Application.Current.Exit();
	}  
```

### ListBox

### CheckBox

### RadioButton 

Agrupem 
```XML
	<StackPanel>
			<RadioButton Content="Blue" GroupName="BorderBrush" Tag="Blue" Checked="BorderRadioButton_Checked"/>
			<RadioButton Content="White" GroupName="BorderBrush" Tag="White"  Checked="BorderRadioButton_Checked"/>
	</StackPanel>
```			