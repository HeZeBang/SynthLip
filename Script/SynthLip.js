// JavaScript source code
// Synth Lip Script(Developer Preview)
// Author: ZAMBAR
// Github repo: https://github.com/HeZeBang/SynthLip

const DbgMode = false;
const version = 0x000207;
const version2 = "alpha";
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
    var content = "[#SYNTHLIP INFO]\nPrjPath:{0}\nEditTime:{1}\nNoteCount:{2}\nScriptVersion:{3} - {4}\nPrjName:{5}\nTrack:{6}\nTrackName:{7}\n".format(SV.getProject().getFileName(), timecnt, cnt, version, version2, name, trkidx, SV.getProject().getTrack(trkidx).getName());
    for (i = 0, content += "[NOTE{0}]\n".format(i); i < cnt; i ++, content += "[NOTE{0}]\n".format(i))
        //for (j = 0; j < notedat[i].num; j ++)
            for (k in notedat[i])
                content += "{0}:{1}\n".format(k,notedat[i][k]);

    // var path = SV.getProject().getFileName().substr(0,SV.getProject().getFileName().length - 3);
    // var fso = new ActiveXObject("Scripting.FileSystemObject"); 
    // SV.showMessageBox(path, "{0}txt".format(path));
    // var file = fso.CreateTextFile("{0}txt".format(path), true);
    // file.WriteLine(content);
                
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
                "lrc": "-", //Lyric
                "ons": 0,   //NoteOnset
                "dur": 0,   //NoteDuration
                "num": 0,   //Num of Phonemes
                "phn": [],  //Phonemes
                "scl": [],  //Scale of Duration
                "pit": 60
            }
            var idx = 0;    //idx index of pho
            var dur = grp.getNote(i).getAttributes().dur;   //dur.length为0时表示未更改而不是单音素 且len只能表示前几个更改 idx才是真正的音素数

            //get phns
            for (tmp = phogr[i].indexOf(' '); tmp !== -1; tmp = phogr[i].indexOf(' ', tmp + 1))
                idx ++;
                notetmpdata.phn = (phogr[i] == "")?    "-":(grp.getNote(i).getPhonemes() == "")?   phogr[i].split(' '):grp.getNote(i).getPhonemes().split(' ');
           
            idx ++;
            dat[idxnote] = new Array();
            notetmpdata.ons = SV.getProject().getTimeAxis().getSecondsFromBlick(grp.getNote(i).getOnset());
            notetmpdata.dur = SV.getProject().getTimeAxis().getSecondsFromBlick(grp.getNote(i).getEnd()) - SV.getProject().getTimeAxis().getSecondsFromBlick(grp.getNote(i).getOnset());
            notetmpdata.num = idx;
            notetmpdata.lrc = grp.getNote(i).getLyrics();
            notetmpdata.pit = grp.getNote(i).getPitch();
            adlg("No." + idxnote + "->   " + notetmpdata.lrc);

            for (j = 0; j < idx; j ++)
            {
                var bpm = SV.getProject().getTimeAxis().getTempoMarkAt(grp.getNote(i).getOnset()).bpm;
                //logs+="dur:" + notedat[idxnote].dur + ";";
                notetmpdata.scl[j] = (dur[j] == undefined)? 1:dur[j];
                //SV.showMessageBox(notedat[idxnote].num + idx , notedat[idxnote].scl[j]);
                //dat[idxnote][j]=((dur[j] == undefined)? 1:dur[j]) * SV.blick2Seconds(grp.getNote(i).getDuration(), SV.getProject().getTimeAxis().getTempoMarkAt(grp.getNote(i).getEnd() - grp.getNote(i).getDuration()).bpm)/idx;    //origin array
                //logs += dat[idxnote][j];
                //logs += (dur[j] || 1) * SV.blick2Seconds(grp.getNote(i).getDuration(), SV.getProject().getTimeAxis().getTempoMarkAt(grp.getNote(i).getEnd() - grp.getNote(i).getDuration()).bpm)/idx + ", ";
            }
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
    //SV.showMessageBox("Log at Current:" + SV.getMainEditor().getCurrentTrack().getName() + " #" + i, logs);
   
    logshow("Log at Current:" + SV.getMainEditor().getCurrentTrack().getName() + " #" + i);

    output(idxnote, res.answers.cbtrack);

    SV.finish();
    return 0;
}
