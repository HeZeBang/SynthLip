// JavaScript source code
// Synth Lip Script(Developer Preview)
// Author: ZAMBAR
// Github repo: https://github.com/HeZeBang/SynthLip

const DbgMode = false;
const version = 0x000301;
const version2 = "Alpha";
var logs = "";

function getClientInfo()
{
    return {
        "name": "SynthLip",
        //"category": "ZAMBAR",
        "author": "ZAMBAR",
        "versionNumber": version,
        "minEditorVersion": 0x010300
    };
}

function adlg(a)
{
    logs += a + "\n";
}

function objlog(obj)
{
    if(DbgMode)
    {
        for(i in obj)
            adlg(i, " ",obj[i]);
    }
}

function logshow(Title)
{
    if (DbgMode)
        SV.showMessageBox(Title || "Logs", logs);
}


String.prototype.format = function()
{
    var formatted = this;
    for (var idx in arguments ) {
        formatted = formatted.replace("{" + idx + "}", arguments[idx]);
    }
    return formatted;
};

//init notedata
var notedat =  [], timecnt;

function init()
{
    //gui
    var mainfrm = {
        "title": "SynthLip - 口型动画数据生成",
        "message": "By ZAMBAR\n当前版本: {0} {1}".format(version,version2),
        "buttons": "OkCancel",
        "widgets": [
            {
                "name": "cbtrack", "type": "ComboBox",
                "label": "选择生成口型的Track来源",
                "choices": [],
                "default": 0
            }
        ]
    };

    for (i = 0; i < SV.getProject().getNumTracks(); i ++)
        mainfrm.widgets[0].choices.push("#{0} - {1}".format(i ,SV.getProject().getTrack(i).getName()));
    mainfrm.widgets[0].default = SV.getMainEditor().getCurrentTrack().getIndexInParent();
    mainfrm.widgets[0].choices[mainfrm.widgets[0].default] += SV.T(" (当前)");

    //fetch result
    return SV.showCustomDialog(mainfrm);
}

function output(cnt, trkidx)
{
    var name = SV.getProject().getFileName().substr(SV.getProject().getFileName().lastIndexOf('\\') + 1, SV.getProject().getFileName().length - 3);
    var info = {
        "PrjName": name,
        "PrjPath": SV.getProject().getFileName(),
        "EditTime": timecnt,
        "NoteCount": cnt,
        "ScriptVersion": version,
        "Track": trkidx,
        "TrackName": SV.getProject().getTrack(trkidx).getName(),
        "Notes": notedat
    }

    var content = "#SYNTHLIP INFO\n";
    content += (DbgMode)? JSON.stringify(info, undefined, 4):JSON.stringify(info);
    SV.setHostClipboard(content);
    SV.showMessageBox("完成! 耗时 {0}ms".format(Date.now() - timecnt), (DbgMode)? content:"信息已复制到系统剪贴板! \n请转到SynthLip主程序编辑~\n——ZAMBAR");
}

function main()
{
    var res = init();
    timecnt = Date.now();
    //logshow();

    //fetch data
    var dat = [],
        idxnote = 0;    //idx of note
   
    // for (foo = 0; foo < SV.getProject().getNumTracks(); foo ++)
    for (bar = 0; bar < SV.getProject().getTrack(res.answers.cbtrack).getNumGroups() && res.status; bar ++)
    {
        var grs = SV.getProject().getTrack(res.answers.cbtrack).getGroupReference(bar);
        var phogr = SV.getPhonemesForGroup(grs);
        var grp = grs.getTarget();
        adlg("Now working on " + grp.getName());

        for (i = 0; i < phogr.length; i ++, idxnote ++, notedat.push(notetmpdata))
        {
            //init
            var notetmpdata = {
                "Lrc": "-", //Lyric
                "Ons": 0,   //NoteOnset
                "Dur": 0,   //NoteDuration
                "Num": 0,   //Num of Phonemes
                "Phn": [],  //Phonemes
                "Scl": [],  //Scale of Duration
                "Pit": 60
            }
            var idx = 0;    //idx index of pho
            var dur = grp.getNote(i).getAttributes().dur;   //dur.length为0时表示未更改而不是单音素 且len只能表示前几个更改 idx才是真正的音素数

            //get phns
            for (tmp = phogr[i].indexOf(' '); tmp !== -1; tmp = phogr[i].indexOf(' ', tmp + 1))
                idx ++;
                notetmpdata.Phn = (phogr[i] == "")?    ["-"]:(grp.getNote(i).getPhonemes() == "")?   phogr[i].split(' '):grp.getNote(i).getPhonemes().split(' ');
           
            idx ++;
            dat[idxnote] = new Array();
            notetmpdata.Ons = SV.getProject().getTimeAxis().getSecondsFromBlick(grp.getNote(i).getOnset());
            notetmpdata.Dur = SV.getProject().getTimeAxis().getSecondsFromBlick(grp.getNote(i).getEnd()) - SV.getProject().getTimeAxis().getSecondsFromBlick(grp.getNote(i).getOnset());
            notetmpdata.Num = idx;
            notetmpdata.Lrc = grp.getNote(i).getLyrics();
            notetmpdata.Pit = grp.getNote(i).getPitch();
            adlg("No." + idxnote + "->   " + notetmpdata.Lrc);

            for (j = 0; j < idx; j ++)
                notetmpdata.Scl[j] = (dur[j] == undefined)? 1:dur[j];
        }
    }

    adlg("---------------------Analyze Finished---------------------\nTotal: " + idxnote);

    for (i = 0; i < idxnote && DbgMode; i ++, logs += "\n")
    {
        logs += notedat[i].lrc + "---------------------\n";
        for (j = 0; j < notedat[i].num; j ++)
            for (k in notedat[i])
            logs += /*"[" + i + "," + j + "] "*/k + "=" + notedat[i][k] + "\n";
    }
   
    logshow("Log at Current:" + SV.getMainEditor().getCurrentTrack().getName() + " #" + i);

    output(idxnote, res.answers.cbtrack);

    SV.finish();
    return 0;
}
