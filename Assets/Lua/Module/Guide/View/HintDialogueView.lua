---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by taobw.
--- DateTime: 2020/10/28 11:12
--- 侧边弹出提示对话

local error = error
local HintDialogueItem = require("Module.Guide.View.HintDialogueItem")
local HintDialogueModel = require("Module.Guide.Model.HintDialogueModel")

local prefab = "Prefabs/HintDialogue/HintDialogueView.prefab"

---@class HintDialogueView:View
---@field New fun():HintDialogueView
---@field pos_left_1 UnityEngine.GameObject
---@field pos_left_2 UnityEngine.GameObject
---@field pos_left_3 UnityEngine.GameObject
---@field pos_left_4 UnityEngine.GameObject
---@field pos_right_1 UnityEngine.GameObject
---@field pos_right_2 UnityEngine.GameObject
---@field pos_right_3 UnityEngine.GameObject
---@field pos_right_4 UnityEngine.GameObject
---@field Click UnityEngine.GameObject
---
---@field callback function 销毁时调用
---@field isCanClick boolean 当前是否可以点击
---@field playState number 当前点击状态
local HintDialogueView = class("HintDialogueView", View)

function HintDialogueView:Ctor(cfgInfo, callback)
    self.cfgInfo = cfgInfo --配置数据
    self.callback = callback --销毁时调用
    HintDialogueView.super.Ctor(self, prefab, Constants.LAYER_UI_TOP)
end

function HintDialogueView:OnInitialize()
    HintDialogueView.super.OnInitialize(self)
    GetComponent.RectTransform(self.gameObject).sizeDelta = Vector3.zero
    self.pos_left_1 = self.transform:Find("left/pos_left_1").gameObject
    self.pos_left_2 = self.transform:Find("left/pos_left_2").gameObject
    self.pos_left_3 = self.transform:Find("left/pos_left_3").gameObject
    self.pos_left_4 = self.transform:Find("left/pos_left_4").gameObject
    self.pos_right_1 = self.transform:Find("right/pos_right_1").gameObject
    self.pos_right_2 = self.transform:Find("right/pos_right_2").gameObject
    self.pos_right_3 = self.transform:Find("right/pos_right_3").gameObject
    self.pos_right_4 = self.transform:Find("right/pos_right_4").gameObject
    self.Click = self.transform:Find("Click").gameObject
    AddEventListener(self.Click, PointerEvent.CLICK, self.OnBgClick, self)

    self.parentCfg = {}
    for k, v in pairs(HintDialogueModel.posCfg) do
        self.parentCfg[v] = self[k]
    end

    self.playState = HintDialogueModel.doTextStateCfg.none
    self.index = 1 --当前的下标
    if self.cfgInfo[self.index] == nil then
        error("HintDialogueView 没有取到配置数据")
    end
    self.lastInfo = nil --上一个配置数据
    self.curInfo = nil --当前的配置数据
    self:RefreshClickBg(false)
    local cfg = self.cfgInfo[self.index]
    if cfg.pos == nil then
        error("HintDialogueView 没有配置位置数据")
    end

    --print("你妹啊", cfg.noMask)
    self.noMask = cfg.noMask

    self.hintDialogueItem = HintDialogueItem.New(cfg, self.parentCfg[cfg.pos].transform)
    self.hintDialogueItem:Hide()
    self:RefreshState()

end

function HintDialogueView:RefreshClickBg(flag)
    if flag ~= nil then
        self.isCanClick = flag
    end
    self.Click:SetActive(self.isCanClick and self.noMask ~= true)
end

---在doText状态下点击会直接切换为doTextEnd状态 or 字幕播放结束后自动改为doTextEnd
---在doTextEnd状态下点击后切换为none 切换进下一段
function HintDialogueView:OnBgClick()
    if self.playState == HintDialogueModel.doTextStateCfg.doText then
        self.playState = HintDialogueModel.doTextStateCfg.doTextEnd
        self.hintDialogueItem:EndDoText()

    elseif self.playState == HintDialogueModel.doTextStateCfg.doTextEnd then
        self:RefreshClickBg(false)
        self.playState = HintDialogueModel.doTextStateCfg.none
        self.index = self.index + 1
        self:RefreshState()
    end
end

function HintDialogueView:RefreshState()
    local curInfo = self.cfgInfo[self.index]
    self.curInfo = curInfo
    local isEnterShow = false --是否需要进场动画
    local sequence = DOTween.Sequence()
    self.sequence = sequence
    if curInfo then
        ---还有配置数据 播放对话
        if self.lastInfo == nil then
            --初次显示
            isEnterShow = true
        elseif self.lastInfo.pos ~= curInfo.pos then
            --与上一段的对话的位置不一样 播放离场动画
            isEnterShow = true
            sequence:AppendCallback(function()
                self.hintDialogueItem:LeaveTween()
            end)
            sequence:AppendInterval(self.hintDialogueItem.leaveDuration)
            sequence:AppendCallback(function()
                local parent = self.parentCfg[curInfo.pos]
                self.hintDialogueItem.transform:SetParent(parent.transform)
                self.hintDialogueItem.transform.localPosition = Vector3.zero
            end)
        else
            --相同位置则直接刷新
            self.hintDialogueItem:RefreshFacade(curInfo)
        end

        if isEnterShow then
            --播放进场动画
            sequence:AppendCallback(function()
                self.hintDialogueItem:RefreshFacade(curInfo)
                self.hintDialogueItem:EnterTweenShow()
                if self.hintDialogueItem.gameObject.activeSelf == false then
                    self.hintDialogueItem:Show()
                end
            end)
            sequence:AppendInterval(self.hintDialogueItem.enterDuration)
        end

        sequence:AppendCallback(function()
            self.hintDialogueItem:StartDoText(function()
                self.playState = HintDialogueModel.doTextStateCfg.doTextEnd

                if curInfo.countTime then ---倒计时自动关闭
                    DelayedCall(curInfo.countTime, function()
                        self:OnBgClick()
                    end)
                end
            end)
            self.playState = HintDialogueModel.doTextStateCfg.doText  ---改变当前字幕状态doText
            self:RefreshClickBg(true)
            self.lastInfo = curInfo
        end)
    else
        ---配置数据已读取完毕 结束对话
        sequence:AppendCallback(function()
            self:RefreshClickBg(false)
            self.hintDialogueItem:LeaveTween()
        end)
        sequence:AppendInterval(self.hintDialogueItem.leaveDuration)
        sequence:AppendCallback(function()
            self:Destroy()
        end)
    end
end

function HintDialogueView:OnDestroy()
    HintDialogueView.super.OnDestroy(self)
    if self.callback then
        self.callback()
    end
    if self.sequence then
        self.sequence:Kill()
    end
    self.index = 1
end


return HintDialogueView