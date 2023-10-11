---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by sunshuo.
--- DateTime: 2023/9/6 14:27
--- 全局函数


--- 实现 lua class
---@param className string @ 类名称
---@param superClass table @ -可选- 父类（不能继承 native class）
---@return table
function class(className, superClass)
    local cls = {}
    cls.__classname = className
    cls.__class = cls -- 用于 instanceof() 查询等
    cls.__index = cls

    if superClass ~= nil then
        setmetatable(cls, superClass)
        cls.super = superClass
    else
        cls.Ctor = function()
        end
    end

    function cls.New(...)
        local instance = setmetatable({}, cls)
        instance:Ctor(...)
        return instance
    end

    return cls
end


--- obj 对应的 C# 对象是否为 null
---@param obj any
---@return boolean
function isnull(obj)
    if obj == nil then
        return true
    end
    return _isnull(obj)
end

--- Not a Number
---@param value any
---@return boolean
function isNaN(value)
    return value ~= value
end

--


--- 设置 target 的父节点为 parent。
---@param target UnityEngine.Transform
---@param parent string | UnityEngine.Transform
---@param worldPositionStays boolean @ -可选- 是否保留在世界坐标系中的状态（包括位置和旋转等）。默认：false
function SetParent(target, parent, worldPositionStays)
    -- 传入的 parent 是 图层名称
    if type(parent) == "string" then
        parent = Stage.GetLayer(parent)
    end
    target:SetParent(parent, worldPositionStays == true)
end

--- 销毁 GameObject 或 Component
---@param obj UnityEngine.Object @ 目标对象
---@param delay number @ -可选- 延时删除（秒）
function Destroy(obj, delay)
    if delay == nil then
        GameObject.Destroy(obj)
    else
        GameObject.Destroy(obj, delay)
    end
end