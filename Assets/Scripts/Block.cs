public class Block{
    int type;
    bool fuked;
    bool visible;
    float digtime;

    public void setType(int t){
        this.type = t;
    }
    public int getType(){
        return this.type;
    }

    public void setDigtime(float d){
        this.digtime = d;
    }
    public float getDigtime(){
        return this.digtime;
    }
}