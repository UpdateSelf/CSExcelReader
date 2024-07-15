# CSExcelReader
支持多种引用的Excel配置文件转档工具

## 设计理念
在Sheet的基础上抽象出来DataBlock概念，通常表的最小单位为Sheet, 在CSExcelReader中最小单位是DataBlock, 所以理论上是可以在一张Sheet上完成所有的配置,但不推荐这样做.

一个DataBlock由Name与Scope两个字段确定唯一性，所以一个DataBlock也可以分散在多个Sheet中或者多个Excel文件中，只要保证每个DataBlock分片的Name，Scope，类型，结构体一致即可(类型与结构体只需在其中一个指定).

DataBlock合并规则：由Co属性指定合并顺序，所有的DataBlock的结构字段会合并到同一个结构体上（竖表：排在后面DataBlock的字段会覆盖前面相同名字的字段）.

既然DataBlock唯一性已经确定了，那引用自然就好办了，只需要为引用指令指定DataBlock就可以了.

通过引用与竖表配合很容易的配置出类似json那种复杂，且多层嵌套的配置.

最后通过合理的设计别名表，可以让指令更加简洁直观易维护.

## Features:
1.支持多种数据表：横表，竖表，结构定义表，枚举定义表，别名定义表.

2.支持多种引用：引用横表的一行，引用竖表的某个字段，引用整个DataBlock.

3.支持多种基础类型：bool，byte，short，int，long，float，double，decimal，string，date，span.

4.支持大量的命令，满足项目不同的需求.

5.一键转档与代码生成，使用简单. 每个DataBlock会根据名字生成一个单例类。

6.支持Tag定义，多种环境（开发，测试，发布）一键切换，前后资源代码分开导出（有些字段只能在服务器使用）.

## 使用示例
![example](https://github.com/UpdateSelf/CSExcelReader/blob/main/Pic/example.png)

``` c#
//初始化
DataBlockManager.I.Init(name => Resources.Load<TextAsset>($"GameConfigs/{name}").bytes);
//读取名字为PlayerInfos的DataBlock的PlayerItem字段的Name值
Debug.Log(PlayerInfos.V.PlayerItem.Name);
```

## 使用说明
1.在Resources文件夹下创建CSExcelReader的配置文件.

2.填写CSExcelReader配置文件中相应的字段：资源导出路径，代码导出路径， Excel文件夹（可指定多个）.

3.执行Tools/CSExcelReader/xxxxxx 命令.

### 指令列表
#### B
定义一个DataBlock，每个DataBlock必须以这个命令开始。示例格式：#B Na:GameConfigs, Sc:GameConfig.Test
##### 参数
Na: 设置DB的名字 （HT,VT 必须要有）

Sc: 设置DB的命名空间（HT,VT 必须要有）

Bt: 设置DB的类型，目前支持以下几种：
    
    HT:横表
    VT:竖表
    AD:别名表
    ED:枚举表
    SD:结构定义表
Ds:设置DB数据的结构体，支持项目已有的类型。

Dsp:设置DB数据结构体的父类。

As:设置别名表的作用范围，默认是当前Excel文件，可选值有：1(当前Sheet) 2(当前Excel文件，默认) 3（全局）

Co:设置DB合并时候的顺序，转档后同名的DB会合并。

NSI:不生成读取单列代码

NFT:没有字段的类型, 表头只有一行

NES:不导出脚本，用于类型定义的扩展


#### A
设置DB中的别名，示例格式：#A LT:Game.Test.GameLevel, LTS:Game.Test.Gamelevels

#### FRS 
字段的默认引用信息 ，示例格式：#FRS GameLevel:R Gamelevels。
（字段名，引用类型，引用目标）

#### FTS
设置字段的Tag ，定义是否导出. 示例格式：#FTS Name:S,C Age:S

#### FBI
设置需要建立索引的字段. 通过RK或则RKS引用的目标必须要有此值. 示例格式：#FBI Name,Age

#### FBG
设置需要建立分组的字段. 通过RG引用的目标必须要有此值. 示例格式：#FBG Name,Age

#### FBR
设置需要建立范围引用的字段. 通过RR引用的目标必须要有此值. 示例格式：#FBR Name,Age

#### CF
字段的子字段， 用于字段明字定义的格子. 示例格式：#CF Name,Age

#### TS
根据Tags选择不同的值 示例格式：

#TS 1, S(2)  如果定义了S这个Tag值就为2， 否则值就为1.

#TS 1, S|C(2)  如果定义了S或者C两个其中一个Tag值就为2， 否则值就为1.

#TS 1, S&C(2)  如果同时定义了S与C两Tag值就为2， 否则值就为1.

#### AE
数组结束命令,用于有字符串的数组，一般情况下最后一个格子为空就代表数组结束

#### SE
空字符串

### 引用命令列表

#### R
通过横表的行数引用。 示例格式：

#R GameLevels 0  引用名为GameLevels的DB的第1行数据

#### RS
通过横表的行数引用多个. 示例格式：

#RS GameLevels 0 1 引用名为GameLevels的DB的第1行与第2行数据
#RS GameLevels 0 3-9 引用名为GameLevels的DB的第1行与第4行到第10行的数据，返回一个数组.

#### RF
引用竖表的字段. 示例格式：

#RF PlayerInfo Name 引用名为PlayerInfo的DB的Name字段

#### RK
通过横表的Key引用. 示例格式：

#RK GameLevels Id 1 引用名为GameLevels的DB中Id等于1的那一行.

#### RKS
通过横表的Key引用多个. 示例格式：

#RKS GameLevels Id 1 2 引用名为GameLevels的DB中Id等于1与2的那两行.

#### RG
通过横表的Key引用多个组. 示例格式：

#RG GameLevels Name aa  将名为GameLevels的DB中行通过Name字段分组后，引用Name为aa的那一组
#RG GameLevels Name aa bb  将名为GameLevels的DB中行通过Name字段分组后，引用Name为aa与bb的两组的合集

#### RB
引用整个数据块. 示例格式：

#RB GameLevels  引用名为GameLevels的DB中所有行, GameLevels为横表.
#RB PlayerInfo  引用名为PlayerInfo的DB的值, PlayerInfo为竖表.

#### RR
引用一个或则多个范围. 示例格式：
#RKS GameLevels Level 3-9  引用名为GameLevels的DB中Level值介于3到9的所有行.

