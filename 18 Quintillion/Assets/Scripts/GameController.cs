using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public GameObject worldNumberText;
    public GameObject mainText;
    public GameObject[] resourceTexts;
    public GameObject[] resourceStockpileTexts;
    int[] resourceGains;
    int[] resourceStockpiles;
    private float lampSpeed = 1.6f;
    private float lampCounter = 0.2f;
    private int activeLamps = 5;
    public GameObject[] lamps;
    public Sprite[] lampSprites;
    int currentLamp = 0;

    public AudioSource buttonSound;
    public AudioSource[] clickSounds;

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

    // Use this for initialization
    void Start () {

        resourceGains = new int[10];
        resourceStockpiles = new int[10];

        part1.Add("mainly ");
        part1.Add("fabulously ");
        part1.Add("wholly ");
        part1.Add("remarkably ");
        part1.Add("glaringly ");
        part1.Add("subtly ");
        part1.Add("entirely ");
        part1.Add("partly ");
        part1.Add("seemingly ");

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

        part3.Add("geologically ");
        part3.Add("biospherically ");
        part3.Add("aurally ");
        part3.Add("erotically ");
        part3.Add("geophysically ");
        part3.Add("atmospherically ");
        part3.Add("religiously ");
        part3.Add("ideologically ");
        part3.Add("heart-breakingly ");
        part3.Add("philosophically ");

        part4.Add("exceptional, ");
        part4.Add("unremarkable, ");
        part4.Add("improbable, ");
        part4.Add("astounding, ");
        part4.Add("amusing, ");
        part4.Add("flourishing, ");
        part4.Add("wearisome, ");
        part4.Add("suspect, ");
        part4.Add("legendary, ");
        part4.Add("porous, ");

        part5.Add("hollow and ");
        part5.Add("dense and ");
        part5.Add("dented and ");
        part5.Add("cracked and ");
        part5.Add("catastrophically shattered, ");
        part5.Add("delightfully ");
        part5.Add("invitingly ");
        part5.Add("incredibly smooth, ");
        part5.Add("");
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
        part7.Add("ring ");
        part7.Add("artefact ");

        part8.Add("heavy with ");
        part8.Add("richly endowed with ");
        part8.Add("with just about enough harvestable ");
        part8.Add("with heaps and heaps of ");
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
        part9.Add("COMPREHENSION OF THE ABSOLUTE, ");

        part10.Add("its meadows ");
        part10.Add("its caverns ");
        part10.Add("its plateaus ");
        part10.Add("its valleys ");
        part10.Add("its lakes and oceans ");
        part10.Add("its jungles ");
        part10.Add("its arctic zones ");
        part10.Add("its surface ");
        part10.Add("its innards ");
        part10.Add("its deserts ");

        part11.Add("full of ");
        part11.Add("dotted with ");
        part11.Add("harbouring ");
        part11.Add("remarkable for their ");
        part11.Add("dominated by ");
        part11.Add("partially covered by ");
        part11.Add("sadly lacking any ");
        part11.Add("thoroughly permeated by ");
        part11.Add("soon to be famous for ");
        part11.Add("welcoming us with ");

        part12.Add("levitating ");
        part12.Add("hidden ");
        part12.Add("carnivorous ");
        part12.Add("withering ");
        part12.Add("weaponisable ");
        part12.Add("hypnotic ");
        part12.Add("pestilential ");
        part12.Add("nourishing ");
        part12.Add("hilariously shaped ");
        part12.Add("psychedelic ");

        part13.Add("palms ");
        part13.Add("tomatoes ");
        part13.Add("grass ");
        part13.Add("mushrooms ");
        part13.Add("lilies ");
        part13.Add("pines ");
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
        part14.Add("and plenty of ");
        part14.Add("competing for space with ");
        part14.Add("as well as ");

        part15.Add("tall ");
        part15.Add("squat ");
        part15.Add("iridescent ");
        part15.Add("cropworthy ");
        part15.Add("delicious ");
        part15.Add("rancid ");
        part15.Add("poetry-inducing ");
        part15.Add("procedurally generated ");
        part15.Add("velvety ");
        part15.Add("severely endangered ");

        part16.Add("shrubs ");
        part16.Add("roots ");
        part16.Add("spruces ");
        part16.Add("vines ");
        part16.Add("pickles ");
        part16.Add("cacti ");
        part16.Add("lichen ");
        part16.Add("seaweed ");
        part16.Add("pistachioes ");
        part16.Add("baobabs ");

        part17.Add("which feed the memorably ");
        part17.Add("which provide shelter for the ");
        part17.Add("frequently trapping the ");
        part17.Add("jealously guarded by ");
        part17.Add("somehow guarding ");
        part17.Add("entirely ignored by the ");
        part17.Add("prized by the ");
        part17.Add("tended by the ");
        part17.Add("giving sustenance to the ");
        part17.Add("excreted on by the ");

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
        part19.Add("heptagonal ");
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
        part21.Add("wallabies ");
        part21.Add("devils ");
        part21.Add("warblers ");
        part21.Add("pidgeons ");

        part22.Add("not forgetting the ");
        part22.Add("who exist in a wary truce with the apex predators, the  ");
        part22.Add("to be much preferred over the ");
        part22.Add("cohabiting the southern part with groups of ");
        part22.Add("cohabiting the northern part with groups of ");
        part22.Add("who can be found always gleefully pestering the ");
        part22.Add("- nasty things who prey upon the ");
        part22.Add("lazing amidst hordes and hordes of ");
        part22.Add("singing in polyphony with a small grouping of ");
        part22.Add("and the ");

        part23.Add("musical ");
        part23.Add("wobbling ");
        part23.Add("massive ");
        part23.Add("miniscule ");
        part23.Add("prickly ");
        part23.Add("ticklish ");
        part23.Add("annoying ");
        part23.Add("topologically challenged ");
        part23.Add("two-faced ");
        part23.Add("bellicose ");

        part24.Add("dolphinoids ");
        part24.Add("annelids ");
        part24.Add("pasta-shapes ");
        part24.Add("bats ");
        part24.Add("exopenguins ");
        part24.Add("viruses ");
        part24.Add("clouds ");
        part24.Add("octopuses ");
        part24.Add("sticks ");
        part24.Add("trombones ");

        part25.Add("which lead us to a nation of ");
        part25.Add("and tribes of ");
        part25.Add("reared by communities of ");
        part25.Add("hunting families of ");
        part25.Add("roaming around vast cities of ");
        part25.Add("dwelling in the ruined complexes of ");
        part25.Add("projected to evolve into ");
        part25.Add("pleading to become ");
        part25.Add("domesticated by a civilisation of ");
        part25.Add("carefully cultivated by a race of ");

        part26.Add("barely sentient ");
        part26.Add("(some would say) primitive ");
        part26.Add("sophisticated ");
        part26.Add("simple but cooperative ");
        part26.Add("extraordinarily civilised ");
        part26.Add("hermetic ");
        part26.Add("pastoral ");
        part26.Add("communist ");
        part26.Add("feudal-capitalistic ");
        part26.Add("combative ");

        part27.Add("game developers ");
        part27.Add("boulders ");
        part27.Add("thistles ");
        part27.Add("energy fields ");
        part27.Add("Australians ");
        part27.Add("microcrystals ");
        part27.Add("jelly ");
        part27.Add("Neo-Kantians ");
        part27.Add("rhubarb-compote ");
        part27.Add("odours ");

        part28.Add("who seem quite happy to trade us their ");
        part28.Add("who could be made to part with their ");
        part28.Add("who will be readily relieved of their ");
        part28.Add("who in rituals of ecstasy discard heaps and heaps of their ");
        part28.Add("whose elders present to us their  ");
        part28.Add("who are practically begging us to lift them to the stars in exchange for their ");
        part28.Add("who vigorously pellet the probe with their ");
        part28.Add("who have begun honouring first contact by staging a display of their ");
        part28.Add("who promise to grant our hearts' deepest desire, as long as that desire is for ");
        part28.Add("who may be swiftly swindled of their ");

        part29.Add("banana peels.");
        part29.Add("bitcoins.");
        part29.Add("transcendental deductions.");
        part29.Add("shabby but kind of novel boardgames.");
        part29.Add("good grammar.");
        part29.Add("beer bottles.");
        part29.Add("upvotes.");
        part29.Add("great nose-composers' works.");
        part29.Add("good vibrations.");
        part29.Add("most advanced shoes.");










    }

    // Update is called once per frame
    void Update () {

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
	}

    void IncrementLamp()
    {
        if(currentLamp == 10)
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
        

        lamps[currentLamp].GetComponent<SpriteRenderer>().sprite = lampSprites[1];

        for (int i = 0; i < lamps.Length; i++)
        {
            if(i != currentLamp)
            {
                lamps[i].GetComponent<SpriteRenderer>().sprite = lampSprites[0];
            }
        }


        // RESOURCES also get incremented here

        for (int i = 0; i < resourceStockpiles.Length; i++)
        {
            if (resourceGains[i] != 0)
            {
                resourceStockpiles[i] += resourceGains[i];
                resourceStockpileTexts[i].GetComponent<Text>().text = resourceStockpiles[i].ToString("N0");
                
            }

        }
    }

    void IncrementActiveLamps()
    {
        activeLamps += 1;
        if(activeLamps > lamps.Length - 1)
        {
            activeLamps = lamps.Length;
        }
        Debug.Log(activeLamps);
    }

    void decrementActiveLamps()
    {
        activeLamps -= 1;
        if(activeLamps < 1)
        {
            activeLamps = 1;
        }
    }

    public void DiscoverNewPlanet()
    {

        // play sound
        buttonSound.Play();

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
        if(!leadingZeroes)
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

            quintillions[i] = Random.Range(0, 10);
            if(quintillions[i] != 0)
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
                if ((i + 1) % 3 == 0 && (i+1) < 30)
                {
                    outputNumber += ",";
                }
            }
        }


        // Write numbers in number chain
        Debug.Log(outputNumber);
        worldNumberText.GetComponent<Text>().text = outputNumber;


        // Generate world description
        string worldText = "";
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
            worldText += part28[quintillions[27]];
            worldText += part29[quintillions[28]];

     

        }
        catch
        {
            worldText = "The probe got lost!";
            worldNumberText.GetComponent<Text>().text = "World: ???";
            worldText = "The probe got lost!";
            mainText.GetComponent<Text>().text = worldText;
        }
        // Increment resource gain from that type of world
        resourceGains[quintillions[8]] += 1;
        string resourceText = "+";
        string resourceNumber = resourceGains[quintillions[8]].ToString("N0");
        resourceTexts[quintillions[8]].GetComponent<Text>().text = "+" + resourceNumber;



        mainText.GetComponent<Text>().text = worldText;
        ChangeCameraBackgroundColour(quintillions[1]);
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



    
}
