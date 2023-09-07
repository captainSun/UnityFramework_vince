---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by sunshuo.
--- DateTime: 2020/12/21 13:30
---
local GuideData = {}

GuideData.GuideRecord = {guideName = "", guideIndex = 0} ---当前引导记录
GuideData.targetList = {} ---@type table<string, UnityEngine.GameObject> 引导对象映射表


-----------------------------------------临时变量-------------------------------------
---
GuideData.curGuideInfo = nil ---@type table 当前的引导段落
GuideData.curGuideName = nil ---@type string 当前引导段落的名字
GuideData.curGuideIndex = nil ---@type number 当前引导段落执行到的下标
GuideData.executeGuideCfg = {} ---@type table 记录执行过的引导名字
GuideData.curGuideAction = nil ---@type Guide.Action.BaseGuideAction 当前在执行的引导命令
GuideData.GuideBlackBg = nil ---@type Guide.View.GuideBlackBg 引导黑色背景
GuideData.GuideSkipBtn = nil ---@type Guide.View.GuideSkipBtnView 跳过引导按钮
GuideData.waitGuideEndList = {}  ---@type table  标记是否等待当前引导结束后 才能播放下一个引导
---

-----------------------------------------日志信息------------------------------------------
---
GuideData.GUIDE_DOING_ERROR = "GUIDE ERROR : 当前有引导在执行 guide【%s】 index【%s】 无法执行引导【%s】"
GuideData.NO_GUIDE_ERROR = "GUIDE ERROR : 没有配置该引导 guide【%s】"
GuideData.NO_COMMAND_ERROR = "GUIDE ERROR : 没有配置引导命令 guide【%s】 index【%s】"
GuideData.NO_ACTION_ERROR = "GUIDE ERROR : 没有定义该命令 guide【%s】 index【%s】 action【%s】]"
GuideData.ACTION_EXECUTE_ERROR = "GUIDE ERROR : 命令执行错误 guide【%s】 index【%s】 action【%s】"
GuideData.ACTION_WAIT_ERROR = "GUIDE ERROR : wait命令超过熔断时间 guide【%s】 index【%s】"
GuideData.TALK_NO_CFG_ERROR = "GUIDE ERROR : talk命令没有配置对话内容 guide【%s】 index【%s】"
GuideData.CAMERA_MOVE_NO_INS_ERROR = "GUIDE ERROR : cameraMove命令没有找到建筑区域实例 guide【%s】 index【%s】 buildingId【%s】"
GuideData.CALL_BACK_ERROR = "GUIDE ERROR : callback命令没有callback guide【%s】 index【%s】"
GuideData.CHECK_SCENE_ERROR = "GUIDE ERROR : checkScene命令没有接收到事件 guide【%s】 index【%s】"
GuideData.CHECK_SUB_SCENE_ERROR = "GUIDE ERROR : checkSubScene命令没有接收到事件 guide【%s】 index【%s】"
GuideData.NO_PER_GUIDE_ERROR = "GUIDE ERROR : 没有配置剧情文件 guide【%s】 performance【%s】"
GuideData.NO_GUIDE_ACTION = "GUIDE ERROR : 当前没有在执行的引导命令"
GuideData.NO_KEY_ERROR = "GUIDE ERROR : key值不存在"
GuideData.JUMP_INIT_ERROR =  "GUIDE ERROR : 跳过命令 配置参数错误 guide【%s】 index【%s】"
GuideData.JUMP_KEY_ERROR =  "GUIDE ERROR : 跳过命令 没有找到指定jumpKey guide【%s】 index【%s】 jumpKey【%s】"
GuideData.IN_AUTO_MERGE_NOTICE = "GUIDE NOTICE : 当前正在进行自动合成  引导guide【%s】自动合成完成后执行"
GuideData.WAIT_NO_FUSE_NOTICE = "GUIDE NOTICE : ！！！！！wait命令没有配置熔断请注意 guide【%s】 index【%s】！！！！！"

GuideData.GUIDE_RECODE_LOG = "GUIDE RECORD : 引导纪录 guide【%s】 index【%s】"


function GuideData.DebugErrorLog(errorStr, ...)
    logError(string.format(errorStr, GuideData.curGuideName, GuideData.curGuideIndex, ...))
end

function GuideData.DebugWarningLog(errorStr, ...)
    logWarning(string.format(errorStr, GuideData.curGuideName, GuideData.curGuideIndex, ...))
end

function GuideData.DebugLoggingLog(errorStr, ...)
    log(string.format(errorStr, GuideData.curGuideName, GuideData.curGuideIndex, ...))
end

return GuideData