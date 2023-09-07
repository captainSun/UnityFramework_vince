---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by sunshuo.
--- DateTime: 2020/12/22 10:56
---
---@class Guide.View.GuideBlackBg:View
local GuideBlackBg = class("Guide.View.GuideBlackBg", View)
local prefab = "Prefabs/Guide/GuideBlackBg.prefab"

function GuideBlackBg:Ctor()
    GuideBlackBg.super.Ctor(self,prefab,Constants.LAYER_GUIDE)
end

function GuideBlackBg:OnInitialize()
    GuideBlackBg.super.OnInitialize(self)
    GetComponent.RectTransform(self.gameObject).sizeDelta = Vector2.zero
    self.cg = GetComponent.CanvasGroup(self.gameObject)
    self.cg.alpha = 0
    self.cg:DOFade(1, 0.25)
end

function GuideBlackBg:Destroy()
    self.cg:DOFade(0, 0.25):OnComplete(function()
        GuideBlackBg.super.Destroy(self)
    end)
end

return GuideBlackBg