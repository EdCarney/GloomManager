
let difficultyAdjustment = 0;
const levels = [0, 0, 0, 0];
const scenarioStats = [
    { "ScenLevel": 0, "MstrLevel": 0, "GoldCnv": 2, "TrapDmg": 2, "BonusXp": 4},
    { "ScenLevel": 1, "MstrLevel": 1, "GoldCnv": 2, "TrapDmg": 3, "BonusXp": 6},
    { "ScenLevel": 2, "MstrLevel": 2, "GoldCnv": 3, "TrapDmg": 4, "BonusXp": 8},
    { "ScenLevel": 3, "MstrLevel": 3, "GoldCnv": 3, "TrapDmg": 5, "BonusXp": 10},
    { "ScenLevel": 4, "MstrLevel": 4, "GoldCnv": 4, "TrapDmg": 6, "BonusXp": 12},
    { "ScenLevel": 5, "MstrLevel": 5, "GoldCnv": 4, "TrapDmg": 7, "BonusXp": 14},
    { "ScenLevel": 6, "MstrLevel": 6, "GoldCnv": 5, "TrapDmg": 8, "BonusXp": 16},
    { "ScenLevel": 7, "MstrLevel": 7, "GoldCnv": 6, "TrapDmg": 9, "BonusXp": 18},
];
const maxScenarioLevel = Math.max.apply(Math, scenarioStats.map(x => x["ScenLevel"]));
const difficultyAdjustments = [
    { "Difficulty": "easy",     "Adjustment": -1 },
    { "Difficulty": "normal",   "Adjustment":  0 },
    { "Difficulty": "hard",     "Adjustment":  1 },
    { "Difficulty": "veryHard", "Adjustment":  2 },
];

jQuery("input[name=level-player1]").change(function() {
    levels[0] = parseInt(this.value);
    RecalculateStats();
})

jQuery("input[name=level-player2]").change(function() {
    levels[1] = parseInt(this.value);
    RecalculateStats();
})

jQuery("input[name=level-player3]").change(function() {
    levels[2] = parseInt(this.value);
    RecalculateStats();
})

jQuery("input[name=level-player4]").change(function() {
    levels[3] = parseInt(this.value);
    RecalculateStats();
})

jQuery(".btn-group-toggle input:radio").change(function() {
    let value = jQuery(this).val();
    difficultyAdjustment = difficultyAdjustments.find(x => x["Difficulty"] == value)["Adjustment"];
    RecalculateStats();
})

function RecalculateStats() {
    let recScenarioLevel =  CalculateRecommendedScenarioLevel();
    SetScenarioStats(recScenarioLevel + difficultyAdjustment);
}

/**
 * Calculates the recommended scenario level for the party
 * as the average level of the (non-zero level) party members
 * divided by two, rounded up.
 */
function CalculateRecommendedScenarioLevel() {
    let totalLevel = 0;
    levels.forEach(level => totalLevel += level);
    let numNonzeroLevels = levels.filter(level => level > 0).length;
    if (numNonzeroLevels > 0) {
        let avgLevel = totalLevel / numNonzeroLevels;
        return Math.ceil(avgLevel / 2);
    }
    else {
        return 0;
    }
}

/**
 * Updates the scenario stats to align with the scenario stat
 * settings based on the provided recommended scenario level.
 */
function SetScenarioStats(scenarioLevel) {
    // reduce level and display alert if above max level
    if (scenarioLevel >= maxScenarioLevel) {
        jQuery("#alert-max-scenario").prop("hidden", false);
        scenarioLevel = maxScenarioLevel;
    }
    else {
        jQuery("#alert-max-scenario").prop("hidden", true);
    }
    let stats = scenarioStats.find(x => x["ScenLevel"] == scenarioLevel);    
    jQuery("#lvl-scen-rec").text(stats["ScenLevel"]);
    jQuery("#lvl-mstr-rec").text(stats["MstrLevel"]);
    jQuery("#gold-cnv-rec").text(stats["GoldCnv"]);
    jQuery("#trap-dmg-rec").text(stats["TrapDmg"]);
    jQuery("#bonus-xp-rec").text(stats["BonusXp"]);
}