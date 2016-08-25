using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    private float secondTick = 1.0f;
    private int levelTicker = 0;
    private int clickCounter;
    private bool buildatron = false;
    bool ended = false;
    public GameObject worldNumberText;
    public GameObject mainText;
    public GameObject rankText;
    public GameObject tvText;
    public GameObject[] debugTexts;
    public GameObject[] resourceTexts;
    public GameObject[] resourceStockpileTexts;
    public GameObject[] resourceCostTexts;
    int[] resourceCosts;
    public GameObject engineText;
    public GameObject textSpawn;
    int[] resourceGains;
    int[] resourceStockpiles;
    private float lampSpeed = 1.7f;
    private float lampCounter = 0.2f;
    private int activeLamps = 2;
    public GameObject[] lamps;
    public GameObject[] lampTexts;
    public Sprite[] lampSprites;
    public GameObject[] blinkArrows;
    public Sprite[] blinkArrowSprites;
    int currentLamp = 0;

    // Basebuilding
    bool baseBuilding = true;
    int baseCounter = 0;
    public GameObject[] baseLights;



    public AudioSource buttonSound;
    public AudioSource failedLaunch;
    public AudioSource[] clickSounds;
    public AudioSource arrivalSound;
    public AudioSource questWorldSound;

    public AnimationCurve[] levels;


    public int costLevel = 1;
    private bool discoveringPlanet = false;

    // Plot progression
    private int progressionChance = 0;

    // quest state
    public int questTargetWorld = -1;
    private int questWorldsVisited = 0;


    // quest descriptions
    List<string> questTexts = new List<string>();

    List<string> part1 = new List<string>();
    List<string> part2 = new List<string>();
    List<string> part3 = new List<string>();
    List<string> part4 = new List<string>();
    List<string> part5 = new List<string>();
    List<string> part6 = new List<string>();
    List<string> part7 = new List<string>();
    List<string> part8 = new List<string>();
    List<string> part9 = new List<string>();
    List<string> part10 = new List<string>();
    List<string> part11 = new List<string>();
    List<string> part12 = new List<string>();
    List<string> part13 = new List<string>();
    List<string> part14 = new List<string>();
    List<string> part15 = new List<string>();
    List<string> part16 = new List<string>();
    List<string> part17 = new List<string>();
    List<string> part18 = new List<string>();
    List<string> part19 = new List<string>();
    List<string> part20 = new List<string>();
    List<string> part21 = new List<string>();
    List<string> part22 = new List<string>();
    List<string> part23 = new List<string>();
    List<string> part24 = new List<string>();
    List<string> part25 = new List<string>();
    List<string> part26 = new List<string>();
    List<string> part27 = new List<string>();
    List<string> part28 = new List<string>();
    List<string> part29 = new List<string>();
    List<string> part30 = new List<string>();
    List<string> part31 = new List<string>();

    List<string> engineNames1 = new List<string>();
    List<string> engineNames2 = new List<string>();
    List<string> engineNamesCombo = new List<string>();

    List<string> cameraFails = new List<string>();
    // Use this for initialization
    void Start () {

       
        questTargetWorld = -1;
       
        resourceGains = new int[11];
        resourceStockpiles = new int[11];
        resourceCosts = new int[11];

        resourceGains[0] = 1;

        questTexts.Add("The probe lands on a blue planet twinkling in the night, weaving its way down through a heavy mist which blankets weary land. Mighty shapes jut out everywhere, resistant to scans, signs advanced technology or unusual geology perhaps. Small bands of local inhabitants, shrouded in hooded woollen robes, emerge from the greyness and surround your probe. They whisper of a great bearded being who once passed through these lands speaking in sweeping terms of unimaginable bliss. With his words the traveler lured the youth of the local tribe with itself off towards much vaunted miracles at the galactic centre, though what those anointed secrets exactly were, no-one here clearly remembers. The locals present you with an ingredient of Hype: Being Wisely Economical with Information.");
        questTexts.Add("The probe arrives at a dead world orbited by a bustling communications station which is the meeting place of a thousand races; the last, best hope for peace; the nexus of this corner of the galaxy. Docking with the station, the probe is wined and dined and you can share a hundred tales, true or false, from the worlds you have visited with beeps of excitement. In this world of big words, bigger smiles and easy winks you acquire a second ingredient of Hype: A Good Pitch.");
        questTexts.Add("You land on a massive abandoned arkship. The probe can find no control room, no crew. Instead there are doors that lead to other doors, and corridors lined with strange mirrors wherein reanimated slivers of past lives flit by, gilded memories of youth are resurrected and a billion dreams of the future careen into each other. A miracle that even the probe with its miniscule brain struggles to leave behind. You acquire the third and final ingredient of Hype: The Drink Before and the Cigarette After are More Important than the Thing Itself. \n\nYou have acquired all the ingredients of Hype and can keep manufacturing it until Publication Day and beyond!");

        engineNames1.Add("Wood");
        engineNames1.Add("Carbon");
        engineNames1.Add("Benzene");
        engineNames1.Add("Nucular");
        engineNames1.Add("Antiquark");
        engineNames1.Add("Eleriac");
        engineNames1.Add("Dialectical");
        engineNames1.Add("Dilithium");
        engineNames1.Add("Holtzman");
        engineNames1.Add("Hype");

        engineNames2.Add("Stove");
        engineNames2.Add("Locomotivator");
        engineNames2.Add("Combustor");
        engineNames2.Add("Accelerator");
        engineNames2.Add("Pump");
        engineNames2.Add("Kettle");
        engineNames2.Add("Persuader");
        engineNames2.Add("Warpdrive");
        engineNames2.Add("Folder");
        engineNames2.Add("Engine");

        // second part of names should be randomised
        engineNames2.Sort((x, y) => Random.value < 0.5f ? -1 : 1);
        
        for (int i = 0; i < engineNames1.Count; i++)
        {
            engineNamesCombo.Add(engineNames1[i] + "-" + engineNames2[i]);
            Debug.Log(engineNamesCombo[i]);
        }




        cameraFails.Add("Camera out of battery!");
        cameraFails.Add("Lens cap left on, please remove lens cap");
        cameraFails.Add("General camera error");
        cameraFails.Add("Camera transmission error");
        cameraFails.Add("Please plug in camera cable ");
        cameraFails.Add("Camera not working, please turn off and on again");
        cameraFails.Add("Camera out of battery! Please send money to Probatron Services for replacement");
        cameraFails.Add("Now don't panic but the camera doesn't seem to be working");
        cameraFails.Add("Camera gone broke down again");
        cameraFails.Add("The camera is out of batteries but can we suggest you use your imagination instead?");
        cameraFails.Add("Unknown camera issue - sorry about that");
        cameraFails.Add("Hmm, the camera is not working. Close your eyes and wish upon a star?");



        part1.Add("mainly ");
        part1.Add("fabulously ");
        part1.Add("eye-poppingly ");
        part1.Add("remarkably ");
        part1.Add("glaringly ");
        part1.Add("disgustingly ");
        part1.Add("entirely ");
        part1.Add("mind-crushingly ");
        part1.Add("unnaturally ");

        part2.Add("pink, ");
        part2.Add("green, ");
        part2.Add("grey, ");
        part2.Add("brown, ");
        part2.Add("blue, ");
        part2.Add("bland, ");
        part2.Add("orange, ");
        part2.Add("yellow, ");
        part2.Add("red, ");
        part2.Add("purple, ");

        part3.Add("artistically ");
        part3.Add("biospherically ");
        part3.Add("aurally ");
        part3.Add("erotically ");
        part3.Add("geophysically ");
        part3.Add("atmospherically ");
        part3.Add("religiously ");
        part3.Add("ideologically ");
        part3.Add("technically ");
        part3.Add("philosophically ");

        part4.Add("unremarkable, ");
        part4.Add("suspect, ");
        part4.Add("improbable, ");
        part4.Add("wearisome, ");
        part4.Add("amusing, ");
        part4.Add("porous, ");
        part4.Add("flourishing, ");
        part4.Add("perverted, ");
        part4.Add("happening, ");
        part4.Add("avant-garde, ");

        part5.Add("hollow and ");
        part5.Add("dense and ");
        part5.Add("dented and ");
        part5.Add("cracked and ");
        part5.Add("catastrophically shattered, ");
        part5.Add("delightfully ");
        part5.Add("invitingly ");
        part5.Add("incredibly smooth, ");
        part5.Add("menacingly ");
        part5.Add("");

        part6.Add("tiny ");
        part6.Add("small ");
        part6.Add("average-sized ");
        part6.Add("bloated ");
        part6.Add("dark ");
        part6.Add("oversized ");
        part6.Add("huge ");
        part6.Add("gigantic ");
        part6.Add("monumental ");
        part6.Add("large ");

        part7.Add("arkship ");
        part7.Add("asteroid ");
        part7.Add("bubbleworld ");
        part7.Add("moon ");
        part7.Add("Dyson sphere ");
        part7.Add("planet ");
        part7.Add("planetoid ");
        part7.Add("space turtle ");
        part7.Add("ringworld ");
        part7.Add("artefact ");

        part8.Add("heavy with ");
        part8.Add("richly endowed with readily explotable ");
        part8.Add("with just about enough harvestable ");
        part8.Add("ready to feed our industry with heaps and heaps of ");
        part8.Add("replete with millions of tons of ");
        part8.Add("with modest reserves of ");
        part8.Add("bountifully laden with ");
        part8.Add("remarkable for its rich deposits of ");
        part8.Add("stocked with low-quality ");
        part8.Add("about to make us so very happy once we lay hands on its untouched reserves of ");

        part9.Add("FIREWOOD, ");
        part9.Add("COAL, ");
        part9.Add("OIL, ");
        part9.Add("URANIUM, ");
        part9.Add("ANTIMATTER, ");
        part9.Add("ELERIUM, ");
        part9.Add("UNUNTRIUM, ");
        part9.Add("DILITHIUM, ");
        part9.Add("MELANGE, ");
        part9.Add("HYPE,");

        part10.Add("its meadows ");
        part10.Add("its caverns ");
        part10.Add("its plateaus ");
        part10.Add("its valleys ");
        part10.Add("its lakes and oceans ");
        part10.Add("its jungles ");
        part10.Add("its lofty peaks ");
        part10.Add("its surface ");
        part10.Add("its innards ");
        part10.Add("its deserts ");

        part11.Add("full of ");
        part11.Add("dotted with ");
        part11.Add("harbouring ");
        part11.Add("remarkable for their ");
        part11.Add("dominated by ");
        part11.Add("partially covered by ");
        part11.Add("adorned by ");
        part11.Add("thoroughly permeated by ");
        part11.Add("soon to be famous for ");
        part11.Add("crammed to the brim with  ");

        part12.Add("levitating ");
        part12.Add("evaginated ");
        part12.Add("carnivorous ");
        part12.Add("withering ");
        part12.Add("weaponisable ");
        part12.Add("hypnotic ");
        part12.Add("pestilential ");
        part12.Add("politically astute ");
        part12.Add("hilariously shaped ");
        part12.Add("psychedelic ");

        part13.Add("palms ");
        part13.Add("tomatoes ");
        part13.Add("grass ");
        part13.Add("mushrooms ");
        part13.Add("lilies ");
        part13.Add("kumquats ");
        part13.Add("tulips ");
        part13.Add("ferns ");
        part13.Add("potatoes ");
        part13.Add("yams ");

        part14.Add("and ");
        part14.Add("found within ");
        part14.Add("containing ");
        part14.Add("overshadowed by ");
        part14.Add("leeching off ");
        part14.Add("in harmony with ");
        part14.Add("intertwined with ");
        part14.Add("emitting beeps when found near ");
        part14.Add("competing for space with ");
        part14.Add("as well as ");

        part15.Add("(probably) fermentable ");
        part15.Add("squat ");
        part15.Add("iridescent ");
        part15.Add("cropworthy ");
        part15.Add("delicious ");
        part15.Add("rancid ");
        part15.Add("poetry-inducing ");
        part15.Add("procedurally generated ");
        part15.Add("velvety ");
        part15.Add("severely endangered ");

        part16.Add("shrubberies ");
        part16.Add("roots ");
        part16.Add("spruces ");
        part16.Add("vines ");
        part16.Add("pickles ");
        part16.Add("cacti ");
        part16.Add("lichen ");
        part16.Add("seaweed ");
        part16.Add("pistachioes ");
        part16.Add("baobabs ");

        part17.Add("which form the primary sustenance of the roaming ");
        part17.Add("which provide shelter for the indigenous ");
        part17.Add("frequently trapping the ");
        part17.Add("jealously guarded by ");
        part17.Add("providing protected habitats for the local ");
        part17.Add("entirely ignored by the ");
        part17.Add("prized by the ");
        part17.Add("tended by the ");
        part17.Add("giving sustenance to the ");
        part17.Add("furiously excreted on by the ");

        part18.Add("finned, ");
        part18.Add("birdlike, ");
        part18.Add("mammalian, ");
        part18.Add("");
        part18.Add("marsupial, ");
        part18.Add("insectoid, ");
        part18.Add("dewborne, ");
        part18.Add("mechanical, ");
        part18.Add("whispering, ");
        part18.Add("crustacean, ");

        part19.Add("rumbling ");
        part19.Add("ferocious ");
        part19.Add("enlightened ");
        part19.Add("bioluminescent ");
        part19.Add("altruistic ");
        part19.Add("cuddly ");
        part19.Add("heptagonally gendered ");
        part19.Add("delicious ");
        part19.Add("delicate ");
        part19.Add("nocturnal ");

        part20.Add("parrot-");
        part20.Add("bear-");
        part20.Add("dust-");
        part20.Add("bone-");
        part20.Add("rock-");
        part20.Add("cat-");
        part20.Add("lava-");
        part20.Add("mind-");
        part20.Add("ant-");
        part20.Add("tango-");

        part21.Add("things ");
        part21.Add("crabs ");
        part21.Add("baboons ");
        part21.Add("moths ");
        part21.Add("lemurs ");
        part21.Add("chameleons ");
        part21.Add("sturgeons ");
        part21.Add("devils ");
        part21.Add("warblers ");
        part21.Add("pidgeons ");

        part22.Add("second on this world only to the ");
        part22.Add("who exist in a wary truce with the world's apex predators, some ");
        part22.Add("who are frankly no better dinner company than the ");
        part22.Add("cohabiting the southern part with groups of ");
        part22.Add("cohabiting the northern part with groups of ");
        part22.Add("who are often found gleefully pestering the ");
        part22.Add("- nasty things who prey upon the ");
        part22.Add("lazing amidst hordes and hordes of ");
        part22.Add("singing in polyphony with a small grouping of ");
        part22.Add("and the ");

        part23.Add("melodious ");
        part23.Add("wobbling ");
        part23.Add("massive ");
        part23.Add("miniscule ");
        part23.Add("prickly ");
        part23.Add("ticklish ");
        part23.Add("magnetic ");
        part23.Add("topologically challenged ");
        part23.Add("two-faced ");
        part23.Add("bellicose ");

        part24.Add("dolphinoids");
        part24.Add("genital warts");
        part24.Add("pasta-shapes");
        part24.Add("bats");
        part24.Add("exopenguins");
        part24.Add("viruses");
        part24.Add("clouds");
        part24.Add("octopuses");
        part24.Add("nano-sticks");
        part24.Add("trombones");

        part25.Add(". Riding these beasts there is a nation of ");
        part25.Add(" and tribes of ");
        part25.Add(" reared by communities of ");
        part25.Add(" hunting families of ");
        part25.Add(" roaming around vast cities of ");
        part25.Add(" dwelling in the ruined complexes of ");
        part25.Add(". These curious creatures are being ruthlessly slaughtered towards extinction by a roaming horde of ");
        part25.Add(". These beings, who are actually the smartest things on the world, are typically worn as hats by the local, ");
        part25.Add(" who have been domesticated by a civilisation of ");
        part25.Add(" carefully cultivated by a race of ");

        part26.Add("barely sentient ");
        part26.Add("(some would say) primitive ");
        part26.Add("highly opinionated ");
        part26.Add("deeply contemplative ");
        part26.Add("practically celibate ");
        part26.Add("questionably garbed ");
        part26.Add("painfully self-aware ");
        part26.Add("communist ");
        part26.Add("feudal-capitalistic ");
        part26.Add("threateningly well-endowed ");

        part27.Add("game developers ");
        part27.Add("boulders ");
        part27.Add("stand-up comedians ");
        part27.Add("energy fields ");
        part27.Add("Australians ");
        part27.Add("microcrystals ");
        part27.Add("jellies ");
        part27.Add("Neo-Kantians ");
        part27.Add("rhubarb-compote ");
        part27.Add("odours ");

        part28.Add("who themselves seem quite happy to trade us their ");
        part28.Add("who could be made to part with their ");
        part28.Add("who will be readily relieved of their ");
        part28.Add("who in endless rituals of ecstasy jettison heaps and heaps of their ");
        part28.Add("whose elders solemnly present to us their ");
        part28.Add("who are practically begging us to lift them to the stars in exchange for their ");
        part28.Add("who vigorously pellet the probe with their ");
        part28.Add("who have begun honouring first contact by staging a display of their ");
        part28.Add("who promise to grant our hearts' deepest desire, as long as that desire is for ");
        part28.Add("who, might I suggest, may be swiftly swindled of their ");

        part29.Add("who unshackled by patriarchy live in superabundance, and offer us great quantities of ");
        part29.Add("who stage civilisation-wide competitions every four world-cycles over their ");
        part29.Add("who are obsessed by rumours of a great bearded being who will bestow heaven in exchange for ");
        part29.Add("who in autoflaggellating processions forever travel the lands seeking ");
        part29.Add("who dance desperately to a mournful tune bemoaning the loss of their ");
        part29.Add("who keep making lofty promises of one day giving us ");
        part29.Add("who boringly without any resistance allow us to take all their resources in exchange for some of our ");
        part29.Add("who don't even know what possessing things is and are happily relieved of their ");
        part29.Add("who will give us their wealth, sure, but insist that we also take their ");
        part29.Add("whose lives are entirely structured around the tragic mediocrity of writing stories, and using the projected moderate literary fame coming from this to acquire some of the galactic region's ");

        part30.Add("banana peels.");
        part30.Add("bitcoins.");
        part30.Add("transcendental deductions.");
        part30.Add("shabby but kind of novel boardgames.");
        part30.Add("good grammar.");
        part30.Add("beer bottles.");
        part30.Add("upvotes.");
        part30.Add("great nose-composers' works.");
        part30.Add("good vibrations.");
        part30.Add("most advanced shoes.");

        
        part31.Add("beloved retro games. ");
        part31.Add("hygiene tips. ");
        part31.Add("gentle cuticle treatments. ");
        part31.Add("foul-smelling but addictive herbal ointment. ");
        part31.Add("ineffable longing. ");
        part31.Add("best cheat codes. ");
        part31.Add("cushion for the pushing.");
        part31.Add("theories of nostalgia. ");
        part31.Add("ethics in game journalism. ");
        part31.Add("existential anguish brought on by a vague feeling that the universe is just a simulation. ");

    }


    void DoOccasionalThings()
    {
        // update the costs just in case
        for (int i = 0; i < activeLamps; i++)
        {
            int purchaseCost = 0;
            if (resourceGains[i] > 0)
            {
                int costLevelLocal = costLevel - i;
                purchaseCost = Fib(costLevelLocal) * 20;

            }

            if (purchaseCost != 0)
            {
                resourceCostTexts[i].GetComponent<Text>().text = "Cost: " + purchaseCost.ToString("N0");
            }
            else
            {
                resourceCostTexts[i].GetComponent<Text>().text = "Cost: 0";
            }

            resourceCosts[i] = purchaseCost;
        }

        // Display rank
        int rankCount = 0;
        for(int i = 0; i < resourceGains.Length; i++)
        {
            if(resourceGains[i] > 0)
            {
                rankCount = i;
            }

        }
        if (rankCount == 1)
        {
            rankText.GetComponent<Text>().text = "\"Miner\"";
        }

        if (rankCount == 2)
        {
            rankText.GetComponent<Text>().text = "\"Pumper\"";
        }

        if (rankCount == 3)
        {
            rankText.GetComponent<Text>().text = "\"Scientist\"";
        }
        if (rankCount == 4)
        {
            rankText.GetComponent<Text>().text = "\"Prober\"";
        }
        if (rankCount == 5)
        {
            rankText.GetComponent<Text>().text = "\"Sage\"";
        }
        if (rankCount == 6)
        {
            rankText.GetComponent<Text>().text = "\"Semi-Pro\"";
        }
        if (rankCount == 7)
        {
            rankText.GetComponent<Text>().text = "\"Boss\"";
        }
        if (rankCount == 8)
        {
            rankText.GetComponent<Text>().text = "\"Navigator\"";
        }
        if (rankCount == 9)
        {
            rankText.GetComponent<Text>().text = "\"Enlightened\"";
        }

        engineText.GetComponent<Text>().text = "Probe propulsion brought to you by: " + engineNamesCombo[rankCount];
    }

    // Update is called once per frame
    void Update () {

        secondTick -= Time.deltaTime;
        if(secondTick < 0)
        {
            secondTick = 1.0f;
            DoOccasionalThings();
        }
        // Cycle through dashboard lamps
        lampCounter -= Time.deltaTime; 
        if(lampCounter < 0)
        {
            IncrementLamp();
            Debug.Log("Incrementing lamp");
            lampCounter = lampSpeed / (activeLamps + 1);

        }

	    if(Input.GetKeyDown(KeyCode.G))
        {
            DiscoverNewPlanet();
        }


        // debug controls

        if(Input.GetKeyDown(KeyCode.A))
        {
            decrementActiveLamps();
        } 
        if (Input.GetKeyDown(KeyCode.D))
        {
            IncrementActiveLamps();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RandomiseWorldNumber();
        }

    }

    void IncrementLamp()
    {
        if (currentLamp == 10)
        {
            currentLamp = -1;
        }
        currentLamp += 1;
        // play sound
        int soundNumber = Random.Range(0, clickSounds.Length - 1);

        if (currentLamp >= activeLamps && currentLamp < 10)
        {
            currentLamp = 10;
            soundNumber = clickSounds.Length;
        }
        else
        {
            clickSounds[soundNumber].Play();
        }


        if (currentLamp < lamps.Length - 1)
        {
            lamps[currentLamp].GetComponent<SpriteRenderer>().sprite = lampSprites[1];

        } else
        {
            lamps[currentLamp].GetComponent<SpriteRenderer>().sprite = lampSprites[4];
        }

        for (int i = 0; i < lamps.Length; i++)
        {
            if (i != currentLamp)
            {


                lamps[i].GetComponent<SpriteRenderer>().sprite = lampSprites[0];

                if (resourceStockpiles[i] < resourceCosts[i])
                {
                    lamps[i].GetComponent<SpriteRenderer>().sprite = lampSprites[2];
                }

                if (i == lamps.Length - 1)
                    
            {
                lamps[i].GetComponent<SpriteRenderer>().sprite = lampSprites[3];
            }

            }

            

            
        }

        // Also flash the corresponding arrow
        blinkArrows[currentLamp].GetComponent<SpriteRenderer>().sprite = blinkArrowSprites[1];

        for (int i = 0; i < lamps.Length; i++)
        {
            if (i != currentLamp)
            {
                blinkArrows[i].GetComponent<SpriteRenderer>().sprite = blinkArrowSprites[0];
            }
        }



        try
        {
            // RESOURCES also get incremented here

            for (int i = 0; i < resourceStockpiles.Length; i++)
            {
                if (resourceGains[i] != 0)
                {
                    resourceStockpiles[i] += resourceGains[i];
                    resourceStockpileTexts[i].GetComponent<Text>().text = "Reserve: " + resourceStockpiles[i].ToString("N0");

                }

            }
        }

        catch
        {
            Debug.Log("Something went wrong with resource incrementation");
        }

            


    }

    void IncrementActiveLamps()
    {
        activeLamps += 1;
        if(questWorldsVisited > 2)
        {
            if (activeLamps > lamps.Length - 1)
            {

                activeLamps = lamps.Length;

            }

        }
        else
        {
            if (activeLamps > lamps.Length - 1)
            {

                activeLamps = lamps.Length - 2;

            }
        }


        lampTexts[activeLamps - 1].SetActive(true);
        foreach(Transform t in lampTexts[activeLamps - 1].transform)
        {
            t.gameObject.SetActive(true);
        }
    }

    void decrementActiveLamps()
    {
        activeLamps -= 1;
        if(activeLamps < 1)
        {
            activeLamps = 1;
        }
        lampTexts[activeLamps + 1].SetActive(false);
    }

    bool CanPayForDiscovery(int worldType)
    {
        Debug.Log("Approaching world type " + worldType.ToString());
        bool canPay = true;

        for (int i = 0; i <= worldType; i++)
        {
            int purchaseCost = 0;
            if (resourceGains[i] > 0)
            {
                int costLevelLocal = costLevel - i;
                purchaseCost = Fib(costLevelLocal) * 20;

                resourceCostTexts[i].GetComponent<Text>().text = "Cost: " + purchaseCost.ToString("N0");

                Debug.Log("Drawing from resource number " + i.ToString());
                // resource cost is tenfold the step removed, 10 for first, 100 for second
                // first pass, check if there are enough resources
                Debug.Log("Resource cost would be " + purchaseCost.ToString("N0"));
                if (resourceStockpiles[i] < purchaseCost)
                {

                    Debug.Log("Not enough resource " + i.ToString());
                    return false;
                }
            }

        }


        
        return true;
        
        IncrementActiveLamps();

    }

    public void BuildBase()
    {
        Debug.Log("Building Base Unit");
        
    }

    public void DiscoverNewPlanet()
    {
        bool discoverySucceeds = true;
        int questTargetWorldTemp = -1;
        clickCounter += 1;

        // different behaviour if the world selected is Base Building

        if (ended)
        {
            mainText.GetComponent<Text>().text = "And all this by clicking one button " + clickCounter.ToString("N0") + " times\n\nCONGRATULATIONS, CLICKER.\n\n\n\nThanks for playing!\n\n@_ArchBang";
            ended = false;
            return;
        }

        if (!discoveringPlanet)
        {

            progressionChance += 1;



            discoveringPlanet = true;


            int firstNumber;
            firstNumber = Random.Range(0, 2);

            string outputNumber = "World: ";
            bool leadingZeroes = true;
            if (firstNumber > 0)
            {
                outputNumber += firstNumber.ToString();
                leadingZeroes = false;
            }

            int secondNumber = Random.Range(0, 9);
            if (!leadingZeroes)
            {
                outputNumber += secondNumber.ToString();
                outputNumber += ",";
            }
            else if (secondNumber > 0)
            {
                outputNumber += secondNumber.ToString();
                outputNumber += ",";
                leadingZeroes = false;
            }

            Debug.Log(firstNumber.ToString() + " " + secondNumber.ToString());
            int[] quintillions = new int[30];
            for (int i = 0; i < 30; i++)
            {

                int curveRandomByLevel = Mathf.FloorToInt(CurveWeightedRandom(levels[activeLamps - 1]) * 10);

                // Randomisation weighting should come from the type of world that has been reached
                quintillions[i] = curveRandomByLevel;
                if (quintillions[i] != 0)
                {
                    leadingZeroes = false;
                }
                if (i == 8)
                {
                    // Cheekily replace the 9th number with the currently active lamp number
                    quintillions[i] = currentLamp;



                }
                if (!leadingZeroes)
                {
                    outputNumber += quintillions[i].ToString();
                    if ((i + 1) % 3 == 0 && (i + 1) < 30)
                    {
                        outputNumber += ",";
                    }
                }
            }


            // Write numbers in number chain
            Debug.Log(outputNumber);
            //worldNumberText.GetComponent<Text>().text = outputNumber;


            // Generate world description
            string worldText = "";

            if (quintillions[8] == 9)
            {
                worldText += "You have gained HYPE! The Galaxy is practically yours for the taking. Keep on building it up, there's bound to be a payoff! ";
            }

            worldText += "The probe has landed on a ";
                try
                {


                    worldText += part1[quintillions[0]];
                    worldText += part2[quintillions[1]]; // colour
                    worldText += part3[quintillions[2]];
                    worldText += part4[quintillions[3]];
                    worldText += part5[quintillions[4]];
                    worldText += part6[quintillions[5]];
                    worldText += part7[quintillions[6]];
                    worldText += part8[quintillions[7]];
                    worldText += part9[quintillions[8]]; // Resources!
                    worldText += part10[quintillions[9]];
                    worldText += part11[quintillions[10]];
                    worldText += part12[quintillions[11]];
                    worldText += part13[quintillions[12]];
                    worldText += part14[quintillions[13]];
                    worldText += part15[quintillions[14]];
                    worldText += part16[quintillions[15]];
                    worldText += part17[quintillions[16]];
                    worldText += part18[quintillions[17]];
                    worldText += part19[quintillions[18]];
                    worldText += part20[quintillions[19]];
                    worldText += part21[quintillions[20]];
                    worldText += part22[quintillions[21]];
                    worldText += part23[quintillions[22]];
                    worldText += part24[quintillions[23]];
                    worldText += part25[quintillions[24]];
                    worldText += part26[quintillions[25]];
                    worldText += part27[quintillions[26]];
                    if (quintillions[0] == 0)
                    {
                        worldText += part28[quintillions[27]];
                    }
                    else
                    {
                        worldText += part29[quintillions[27]];
                    }
                    if (quintillions[0] == 0)
                    {
                        worldText += part30[quintillions[28]];
                    }
                    else
                    {
                        worldText += part31[quintillions[28]];
                    }

                    if (progressionChance > Random.Range(5, 10))
                    {
                        // visit next quest world pointer
                        questTargetWorldTemp = Random.Range(1, activeLamps - 1) + questWorldsVisited * 2;
                        if(questTargetWorldTemp > 8)
                    {
                        questTargetWorldTemp = 8;
                    }
                    worldText += " The inhabitants respond to your quest for Hype and suggest you visit the nearest world with " + part9[questTargetWorldTemp].Substring(0, part9[questTargetWorldTemp].Length - 2) + ".";
                        progressionChance = 0;
                        Debug.Log("quest target world is " + questTargetWorldTemp.ToString());
                        // if the player visits the right world after this one, then the progression counter resets and the quest world is visited

                    }

                }
                catch
                {
                    worldText = "The probe got lost!";
                    worldNumberText.GetComponent<Text>().text = "World: ???";
                    worldText = "The probe got lost!\n\nTake care to time the launch well";
                    mainText.GetComponent<Text>().text = worldText;
                    discoverySucceeds = false;

                // If the current lamp is base building and base building is enabled, build a base instead of discovering
                if (baseBuilding && (currentLamp == lamps.Length - 1))
                {
                    BuildBase();
                    
                }
            }



            if (CanPayForDiscovery(quintillions[8]) && discoverySucceeds)
            {

                Debug.Log("fibonacci cost : " + (Fib(costLevel) * 10).ToString());
                // play sound
                buttonSound.Play();

                // take resources
                for (int i = 0; i < quintillions[8]; i++)
                {

                    Debug.Log("Drawing from resource number " + i.ToString());
                    // resource cost is fibonacci of the level index less distance from start node times ten 
                    // first pass, check if there are enough resources

                    int costLevelLocal = costLevel - i;

                    int purchaseCost = Fib(costLevelLocal) * 20;

                    resourceStockpiles[i] -= purchaseCost;


                    // resourceStockpileTexts[i].GetComponent<Text>().text = "Reserves: " + resourceStockpiles[i].ToString("N0");

                    // Create icon to show cost
                    GameObject newText = Instantiate(textSpawn, resourceStockpileTexts[i].transform.position, Quaternion.identity) as GameObject;
                    newText.transform.parent = (GameObject.Find("Canvas").transform);

                    newText.GetComponent<Text>().text = purchaseCost.ToString("N0");


                }

                try
                {
                    // Increment resource gain from that type of world
                    resourceGains[quintillions[8]] += 1;
                    string resourceNumber = resourceGains[quintillions[8]].ToString("N0");
                    resourceTexts[quintillions[8]].GetComponent<Text>().text = "+" + resourceNumber;

                    StartCoroutine(FlickerWorldNumber(1.8f));

                }
                catch
                {
                    Debug.Log("Something went wrong with resource gains");
                }

                // Actually discover world and display text
                if (quintillions[8] != questTargetWorld)
                {
                    StartCoroutine(ChangeWorldTextWithDelay(worldText, outputNumber, 2.2f, false));

                }

                else
                {
                    Debug.Log("quintillions[8] is " + quintillions[8].ToString() + " which matches " + questTargetWorld.ToString());
                    // next quest world has been reached
                    StartCoroutine(ChangeWorldTextWithDelay(questTexts[questWorldsVisited], outputNumber, 2.2f, true));
                    questWorldsVisited += 1;
                    if(questWorldsVisited > 2)
                    {
                        ended = true;
                    }
                    // Other quest progression related stuff here:

                    // Impossible to reach next questTargetWorld 
                    questTargetWorld = -1;

                }
                // mainText.GetComponent<Text>().text = worldText;
                ChangeCameraBackgroundColour(quintillions[1]);

                Debug.Log("world " + quintillions[8].ToString() + " active lamps " + (activeLamps - 1).ToString());

                // Update DISCOVERY COSTS: 
                // Costs in lights above = 0
                // Costs in lights below, follow rule fibo of costlevel minus lamp count times ten
                for (int i = 0; i < activeLamps; i++)
                {
                    int purchaseCost = 0;
                    if (resourceGains[i] > 0)
                    {
                        int costLevelLocal = costLevel - i;
                        purchaseCost = Fib(costLevelLocal) * 20;

                    }

                    if (purchaseCost != 0)
                    {
                        resourceCostTexts[i].GetComponent<Text>().text = "Cost: " + purchaseCost.ToString("N0");
                    }
                    else
                    {
                        resourceCostTexts[i].GetComponent<Text>().text = "Cost: 0";
                    }
                }

                levelTicker += 1;
                if (levelTicker > 2)
                {
                    levelTicker = 0;
                    costLevel += 1;
                }
                if (quintillions[8] == (activeLamps - 1))
                {


                    // Allow next world to be reached
                    IncrementActiveLamps();
                }
 

                ChangeProbecamText();

            }
            else
            {
                failedLaunch.Play();
                questTargetWorld = -1;
                questTargetWorldTemp = -1;
                worldNumberText.GetComponent<Text>().text = "World: ???";
                mainText.GetComponent<Text>().text = "That launch timing was as a bit weird. Not sure we could reach a world with our resources if we went that way.\n\nOh well, stranded now. Better just chop some furniture into firewood now.\n\nBe sure to check there's enough resources in our reserves to get the probe to the next world.";
                discoveringPlanet = false;
                resourceStockpiles[0] += 1;

             
            }


        }
        {
            failedLaunch.Play();

        }


        if(questTargetWorldTemp > 0)

        {
            questTargetWorld = questTargetWorldTemp;
        }
    }


void ChangeCameraBackgroundColour(int colourType)
    {
        float rMin = 0.2f, rMax = 0.4f, gMin = 0.2f, gMax = 0.4f, bMin = 0.2f, bMax = 0.4f;
        
        if(colourType == 0)
        {
            // pink
            rMin = 0.99f;
            rMax = 0.9f;
            gMin = 0.2f;
            gMax = 0.3f;
            bMin = 0.65f;
            bMax = 0.85f;
        } else if (colourType == 1)
        {
            // green
            rMin = 0.05f;
            rMax = 0.15f;
            gMin = 0.8f;
            gMax = 0.99f;
            bMin = 0.4f;
            bMax = 0.55f;

        }
        else if (colourType == 2)
        {
            // grey
            rMin = 0.34f;
            rMax = 0.38f;
            gMin = 0.34f;
            gMax = 0.38f;
            bMin = 0.34f;
            bMax = 0.38f;
        }
        else if (colourType == 3)
        {
            // brown
            rMin = 0.4f;
            rMax = 0.6f;
            gMin = 0.33f;
            gMax = 0.42f;
            bMin = 0.22f;
            bMax = 0.34f;
        }
        else if (colourType == 4)
        {
            // blue
            rMin = 0.2f;
            rMax = 0.4f;
            gMin = 0.25f;
            gMax = 0.55f;
            bMin = 0.7f;
            bMax = 0.9f;
        }
        else if (colourType == 5)
        {
            // bland
            rMin = 0.3f;
            rMax = 0.4f;
            gMin = 0.3f;
            gMax = 0.4f;
            bMin = 0.3f;
            bMax = 0.4f;
        }
        else if (colourType == 6)
        {
            // orange 
            rMin = 0.75f;
            rMax = 0.95f;
            gMin = 0.45f;
            gMax = 0.65f;
            bMin = 0.2f;
            bMax = 0.3f;
        }
        else if (colourType == 7)
        {
            // yellow
            rMin = 0.75f;
            rMax = 0.9f;
            gMin = 0.75f;
            gMax = 0.9f;
            bMin = 0.1f;
            bMax = 0.3f;
        }
        else if (colourType == 8)
        {
            // red
            rMin = 0.7f;
            rMax = 0.9f;
            gMin = 0.05f;
            gMax = 0.25f;
            bMin = 0.05f;
            bMax = 0.25f;
        }
        else if (colourType == 9)
        {
            // purple
            rMin = 0.55f;
            rMax = 0.85f;
            gMin = 0.3f;
            gMax = 0.45f;
            bMin = 0.6f;
            bMax = 0.85f;
        }


        Camera.main.backgroundColor = new Color(Random.Range(rMin, rMax), Random.Range(gMin, gMax), Random.Range(bMin, bMax));

    }

    void UpdateEngineName(int engineLevel)
    {


        engineText.GetComponent<Text>().text = "";

    }

    private IEnumerator FlickerWorldNumber(float d)
    {
        float flickerInterval = 0.08f;
        for (int i = 0; i < d/flickerInterval; i++)
        {
            yield return new WaitForSeconds(flickerInterval);

            RandomiseWorldNumber();

        }
    }

    void RandomiseWorldNumber()
    {
        string outputNumber = "World: ";
        if (Random.Range(0, 1) < 1)
        {
            outputNumber = "World: 1";
        }
        outputNumber += Random.Range(0, 9).ToString() + ",";

        for (int i = 0; i < 30; i++)
        {
            outputNumber += Random.Range(0, 9).ToString();

            if ((i + 1) % 3 == 0 && (i + 1) < 30)
            {
                outputNumber += ",";
            }
        }
        worldNumberText.GetComponent<Text>().text = outputNumber;


    }

    private IEnumerator ChangeWorldTextWithDelay(string s, string worldNumber, float d, bool playSpecialSound)
    {
        mainText.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(2.2f);
        mainText.GetComponent<Text>().text = s;
        worldNumberText.GetComponent<Text>().text = worldNumber;

        discoveringPlanet = false;
        if(playSpecialSound)
        {
            questWorldSound.Play();
        }
    }

    private IEnumerator ChangeProbecamWithDelay(string s, float d)
    {
        string waitingText = "Hyperspace!\n\nApproaching new world";
        for(int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.3f);
            waitingText += ".";
            tvText.GetComponent<Text>().text = waitingText;

        }


        yield return new WaitForSeconds(d);
        arrivalSound.Play();
        
        tvText.GetComponent<Text>().text = s;
    }

    public void ChangeProbecamText()
    {
        // overkill
        foreach(GameObject g in debugTexts)
        {
            g.SetActive(false);
        }

        // clear old text

        string camText = cameraFails[Random.Range(0, cameraFails.Count)];
        StartCoroutine(ChangeProbecamWithDelay(camText, 0.9f));


    }

    public void ToggleSound()
    {
        Debug.Log("Sound toggle");
        if (Camera.main.transform.GetComponent<AudioListener>().enabled)
        {
            Camera.main.transform.GetComponent<AudioListener>().enabled = false;
        }
        else
        {
            Camera.main.transform.GetComponent<AudioListener>().enabled = true;
        }
    }

    float CurveWeightedRandom(AnimationCurve curve)
    {
        return curve.Evaluate(Random.value);
    }

    public static int Fib(int aIndex)
    {
        if (aIndex <= 0) // important, breaking condition for the recursion
            return 0;
        if (aIndex == 1) // important, breaking condition for the recursion
            return 1;
        return Fib(aIndex - 1) + Fib(aIndex - 2); // recursion
    }
}
