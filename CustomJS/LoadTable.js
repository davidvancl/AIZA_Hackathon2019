var PolicieData = new Array();
var HasiciData = new Array();
var ZachrankaData = new Array();
var line;
var completed = false;

var radek;
line = 0;
LoadData("Files/Policie-CR.csv",PolicieData,true,0);
line = 0;
LoadData("Files/Stanice-a-pracoviste-HZS.csv",HasiciData,false,0);
line = 0;
LoadData("Files/Vyjezdove-zakladny-ZZS.csv",ZachrankaData,false,0);

function LoadData(Soubor,witeField,loadToTable,AktualniRadek) {
    Papa.parse(Soubor, {
    download: true,
    before: function()
	{
		line = 0;
	},
    step: function(row) {
        try {
            if(completed){ line = 0;} 
            if(row.data != ""){
                witeField[AktualniRadek] = row.data;

                AktualniRadek++;
        }
        } catch (e) { }
    },
    complete: function() {
            if (loadToTable) {
                ToTable(witeField);
            }
            completed = true;
        
    }
});
    
}