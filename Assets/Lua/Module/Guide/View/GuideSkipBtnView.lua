---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by sunshuo.
--- DateTime: 2021/7/31 15:50
---
---@class Guide.View.GuideSkipBtnView:View
---@field New fun()
local GuideSkipBtnView = class("Guide.View.GuideSkipBtnView", View)
function GuideSkipBtnView:Ctor()
    GuideSkipBtnView.super.Ctor(self, "Prefabs/Guide/GuideSkipBtn.prefab", Constants.LAYER_TOP)
end

function GuideSkipBtnView:OnInitialize()
    GuideSkipBtnView.super.OnInitialize(self)
    Stage.AddDontDestroy(self.gameObject)
    AddEventListener(self.gameObject, PointerEvent.CLICK, self.OnClick, self)
end

function GuideSkipBtnView:Show()

end

function GuideSkipBtnView:OnClick()
    GuideController.SkipGuideAction()
end

return GuideSkipBtnView