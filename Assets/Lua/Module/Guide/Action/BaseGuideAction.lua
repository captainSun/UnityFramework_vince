---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by sunshuo.
--- DateTime: 2020/12/18 17:54
--- 引导命令基类
local GuideData = require("Module.Guide.Model.GuideData")

---@class Guide.Action.BaseGuideAction
---@field New fun():Guide.Action.BaseGuideAction
---@field actionVo Guide.ActionData.BaseGuideActionVo 命令数据
local BaseGuideAction = class("Guide.Action.BaseGuideAction")

function BaseGuideAction:Ctor()
    self.actionVo = GuideData.curGuideInfo[GuideData.curGuideIndex]
end

function BaseGuideAction:Execute()
    if self.actionVo.dependentGuide and GuideData.executeGuideCfg[self.actionVo.dependentGuide] == nil then
        logWarning(string.format("该命令依赖引导【%s】| 当前guide【%s】 index【%s】",
                self.actionVo.dependentGuide,GuideData.curGuideName,GuideData.curGuideIndex))
        self:ActionEnd()
    end
end

function BaseGuideAction:Dispose()
    --将actionVo清理掉 作为当前引导已经结束的标志
    self.actionVo = nil
end

---跳过此命令的回调
---如果重写此方法则代表该命令可以跳过
function BaseGuideAction:SkipCallback()
    print("GuideAction 该命令被跳过", self.actionVo.command, GuideData.curGuideName, GuideData.curGuideIndex)
end

function BaseGuideAction:ActionEnd()
    self:Dispose()
    GuideController.NextAction()
end

return BaseGuideAction

---@class Guide.ActionData.BaseGuideActionVo
---@field jumpKey string 提供给jump命令使用的key
---@field dependentGuide string 当前命令依赖的引导名字
---为解决引导之间的依赖问题 添加了依赖引导名字参数
---命令数据中添加此参数 则该命令是否执行 取决于依赖引导当前是否执行过（根据eGuideData.executeGuideCfg判断）
---若未执行过则该命令跳过 若已执行过则该命令执行


