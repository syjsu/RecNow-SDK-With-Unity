//
//  Header.h
//  RecNow
//
//  Created by Lightning on 15/11/5.
//  Copyright © 2015年 AiPai. All rights reserved.
//

#ifndef RecNowCPlus_h
#define RecNowCPlus_h



#ifdef __cplusplus
extern "C" {
#endif

    bool RNisSupported();
    
    void RNinitRecNowRecord();
    
    void RNstartRecording(bool enableMicrophone);
    
    void RNstopRecording();
    
    void RNdiscardRecording();
    
    void RNshowWorksView();
    
    bool RNisRecording();
    
    bool RNisMicrophoned();
    
    void RNsetAppKey(char *appId);
    
    void RNsetShareKeys(char *QQKey,char *WeiXinKey, char *shareText);
    
    void UnitySendMessage(const char *obj, const char *method, const char *msg);


#ifdef __cplusplus
}




#endif
#endif /* RecNowCPlus_h */
