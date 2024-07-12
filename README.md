# CSExcelReader
Excel 配置文件转档工具,支持多种引用

## 设计理念
在Sheet的基础上抽象出来DataBlock概念，以前表的最小单位为Sheet, 在CSExcelReader中最小单位是DataBlock, 所以理论上是可以在一张Sheet上完成所有的配置。

## Features:
1.支持多种引用。

2.支持多种数据表：横表，竖表，结构定义表，枚举定义表，别名定义表。

3.支持多种基础类型：bool，byte，short，int，long，float，double，decimal，string，date，span。

4.支持大量的命令，满足项目不同的需求。

5.一键转档与代码生成，使用简单。

## 使用示例
![example](https://github.com/UpdateSelf/CSExcelReader/blob/main/Pic/example.png)

      DataBlockManager.I.Init(name => Resources.Load<TextAsset>($"GameConfigs/{name}").bytes);
        Debug.Log(PlayerInfos.V.PlayerItem.Name);

## 使用说明

### 命令列表
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
设置字段的Tag ，定义是否导出

#### FBI
设置需要建立索引的字段

#### FBG
设置需要建立分组的字段

#### FBR
设置需要建立范围引用的字段

#### CF
字段的子字段， 用于字段明定义的格子

#### TS
根据Tags选择不同的值 

#### AE
数组结束命令,用于有字符串的数组，一般情况下最后一个格子为空就代表数组结束

#### SE
空字符串

### 引用命令列表

#### R
通过横表的行数应用

#### RS
通过横表的行数应用多个

#### RF
引用竖表的字段

#### RK
通过横表的Key引用

#### RKS
通过横表的Key引用多个

#### RG
通过横表的Key引用多个组

#### RB
引用整个数据块

#### RR
引用一个或则多个范围