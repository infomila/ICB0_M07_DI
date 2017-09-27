[ ... back  ](../README.md)

# Temes introductoris d'Interfícies

## Contenidors bàsics


### StackPanel

### Grid

```xaml
```

```c#     
```
### Programació dinàmica d'Events

```c#     
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