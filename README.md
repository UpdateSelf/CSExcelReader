# CSExcelReader
Excel 配置文件转档工具,支持多种引用

## 设计理念
    在Sheet的基础上抽象出来DataBlock概念，以前表的最小单位为Sheet, 在CSExcelReader中最小单位是DataBlock, 所以理论上是可以在一张Sheet上完成所有的配置。
## Features:
    1.支持多种引用
    2.支持多种数据表：横表，竖表，结构定义表，枚举定义表，别名定义表
    3.