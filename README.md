# MSBuildExample
一个简单的MSBuild例子

在项目csproj文件中，添加了以下内容。功能是在生成可执行文件之后，将其重命名为自定义的名称，并且将生成的可执行文件、引用的第三方包，以及一个配置文件一起打包成zip文件。

在VS中打开项目之后，使用Release设置生成项目，就会发现在`bin\Release`目录中生成了一个压缩包，包含了所有内容。

```xml
<!--This is my config-->
<PropertyGroup>
  <MyOutputName>ClickMe</MyOutputName>
</PropertyGroup>
<ItemGroup>
  <ZipFiles Include="$(OutputPath)$(MyOutputName).exe"/>
  <ZipFiles Include="$(OutputPath)*.dll"/>
  <ZipFiles Include="$(OutputPath)*.json"/>
</ItemGroup>
<Target Name="AfterBuild" Condition="'$(Configuration)'=='Release'">
  <Copy SourceFiles="$(OutputPath)$(AssemblyName).$(OutputType)" DestinationFiles="$(OutputPath)$(MyOutputName).$(OutputType)" />
  <Zip ZipFileName="$(OutputPath)product.zip" WorkingDirectory="$(OutputPath)" Files="@(ZipFiles)" Flatten="True" />
</Target>
```
`PropertyGroup`是属性组，用来添加一组属性值的。添加之后就可以使用`$(PropertyName)`语法来引用了。例如上面的`$(MyOutputName)`。

`ItemGroup`是项目组，用来引用一个或多个文件的。添加之后可以用`@(ItemName)`语法来引用。例如上面的`@(ZipFiles)`。

`Target`是构建目标，可以指定条件，一个构建目标还可以有多个任务。由于这里引用了`Zip`任务，在MSBuild Community Tasks中定义的，因此这些代码需要添加在`Import`标签之后，否则无法引用。这里的Zip任务通过指定`Flatten=True`让这些要压缩的文件平整压缩，而不是压缩成一个有层次的目录。
