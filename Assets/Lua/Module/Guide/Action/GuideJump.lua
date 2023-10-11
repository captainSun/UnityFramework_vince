---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by sunshuo.
--- DateTime: 2021/8/10 15:30
--- 跳转命令
---@class Guide.Action.GuidJump:Guide.Action.BaseGuideAction
---@field actionVo Guide.ActionData.GuidJumpVo
local GuidJump = class("Guide.Action.GuideDelay", BaseGuideAction)

function GuidJump:Ctor()
    GuidJump.super.Ctor(self)
end

function GuidJump:Execute()
    GuidJump.super.Execute(self)
    if self.actionVo == nil then
        return
    end
    local jumpCheck =  self.actionVo.jumpCheck
    local targetJumpKey = self.actionVo.targetJumpKey
    if jumpCheck == nil or targetJumpKey == nil then
        GuideData.DebugWarningLog(GuideData.JUMP_INIT_ERROR)
        self:ActionEnd()
        return
    end

    if jumpCheck() then
        GuideData.DebugLoggingLog("GuidJump 判断可以跳过")
        GuideController.JumpGuide(targetJumpKey)
    else
        GuideData.DebugLoggingLog("GuidJump 判断不可跳过")
        self:ActionEnd()
    end
end

return GuidJump

---@class Guide.ActionData.GuidJumpVo
---@field jumpCheck fun() 是否可以跳转的判断函数 返回布尔值
---@field targetJumpKey string 跳转的目标jumpKey