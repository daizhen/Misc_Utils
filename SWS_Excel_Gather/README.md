## 使用说明
下载 [ExcelGather](https://github.com/daizhen/Misc_Utils/blob/master/SWS_Excel_Gather/Dists/ExcelGather.zip?raw=true).
解压后运行 ExcelGather.exe
### 目录结构： 文件按照月份进行存放。
        根目录
            1月
              231XXXX.xls
              098AAAAA.xls
            2月
              ....
            3月
              ....
            ....

### 文件名格式：

      编码+名称.xls
### 选择输入、输出文件夹
>输入文件夹是选择根目录文件夹，在这个文件夹下面是1月，2月.....12月子文件夹

>输出文件夹用以输出结果文件。结果文件是名为Result.xls

### 输出文件格式
Result.xls包括12个按月统计的tab和一个Summary汇总的tab
>按月统计的tab包括 原名称，文件名，标准名称，	编号，	钱共5列。

> Summary对每个分支结构进行按月统计汇总。

### 错误消息
错误消息会在界面上显示出来，共包括３中类型的错误, 同时会给出错误的文件名，便于通过文件检查错误。
> 名称错误，没有以【 营业部名称(签章)：】开头  

> 机构编码错误

> 金额提取错误,或金额为0

### 分支机构的增减
通过修改allbranch.xls的内容来增减分支机构。 但必须保持文件结构的正确。
>第一列为编号

> 第二列为名称
